﻿
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using SW.Infolink.Domain;
using Microsoft.EntityFrameworkCore;
using SW.EfCoreExtensions;
using SW.PrimitiveTypes;

namespace SW.Infolink
{
    public class FilterService
    {

        readonly IServiceScopeFactory ssf;
        readonly ILogger<FilterService> logger;
        readonly ReaderWriterLockSlim documentFilterLock = new ReaderWriterLockSlim();
        readonly IDictionary<int, DocumentFilter> documentFilter = new Dictionary<int, DocumentFilter>();


        DateTime documentFilterPreparedOn;

        public FilterService(IServiceScopeFactory ssf, ILogger<FilterService> logger)
        {
            this.ssf = ssf;
            this.logger = logger;
            documentFilterPreparedOn = DateTime.MinValue;
        }

        void Prepare()
        {
            using var scope = ssf.CreateScope();

            var repo = scope.ServiceProvider.GetRequiredService<InfolinkDbContext>();

            documentFilter.Clear();

            var docs = repo.List<Document>();

            foreach (var doc in docs)
            {

                var df = new DocumentFilter();
                documentFilter.Add(doc.Id, df);

                var subs = repo.List(new SubscribersByDocument(doc.Id));//.Select

                if (doc.PromotedProperties.Count == 0)
                {
                    df.SubscribersWihtoutPropertyFilter = subs.Select(e => e.Id).ToArray();
                }
                else
                {
                    foreach (var iprop in doc.PromotedProperties)
                    {

                        var pf = new PropertyFilter(iprop.Value);
                        df.Properties.Add(iprop.Key, pf);

                        foreach (var sub in subs)
                        {
                            if (sub.DocumentFilter.TryGetValue(iprop.Key, out var val))
                            {
                                var valarr = val.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                                foreach (var valitem in valarr)
                                {
                                    var valclean = valitem.Replace("\"", "").Trim().ToLower();
                                    if (string.IsNullOrEmpty(valclean))
                                    {
                                        throw new InfolinkException();
                                    }
                                    else
                                    {
                                        if (!pf.SubscribersByValues.ContainsKey(valclean))
                                            pf.SubscribersByValues[valclean] = new List<int>();
                                        pf.SubscribersByValues[valclean].Add(sub.Id);
                                    }
                                }

                            }
                            else
                            {
                                pf.Ignored.Add(sub.Id);
                            }
                        }
                    }
                }
            }

        }

        public IEnumerable<int> Filter(int documentId, XchangeFile xchangeFile)
        {
            if (xchangeFile is null)
            {
                throw new InfolinkException("Invalid file.");
            }

            documentFilterLock.EnterWriteLock();
            try
            {
                if (DateTime.UtcNow.Subtract(documentFilterPreparedOn).TotalMinutes > 10)
                {
                    logger.LogDebug("Prepare()");
                    Prepare();
                    documentFilterPreparedOn = DateTime.UtcNow;
                }
            }
            finally
            {
                documentFilterLock.ExitWriteLock();
            }

            documentFilterLock.EnterReadLock();
            try
            {
                if (documentFilter[documentId].Properties.Count == 0)
                {
                    return documentFilter[documentId].SubscribersWihtoutPropertyFilter;
                }

                JToken doc = JObject.Parse(xchangeFile.Data);
                HashSet<int> matchall = null;

                foreach (var prop in documentFilter[documentId].Properties.Keys)
                {
                    var pf = documentFilter[documentId].Properties[prop];

                    HashSet<int> matchallprop = new HashSet<int>(pf.Ignored);

                    var node = doc.SelectToken(pf.Path);

                    if (node == null) throw new PromotedPropertyNotPresent(prop);


                    var val = node.Value<string>() == null ? string.Empty : node.Value<string>().ToLower().Trim();

                    if (pf.SubscribersByValues.TryGetValue(val, out var lstall))
                        matchallprop.UnionWith(lstall);

                    if (matchall == null) matchall = matchallprop;
                    else matchall.IntersectWith(matchallprop);

                }

                return matchall;
            }
            finally
            {
                documentFilterLock.ExitReadLock();
            }
        }
    }


}


