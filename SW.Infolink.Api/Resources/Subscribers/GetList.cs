﻿using Microsoft.EntityFrameworkCore;
using SW.Infolink.Domain;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Infolink.Api.Resources.Subscribers
{
    [HandlerName("getlist")]
    class GetList : IQueryHandler
    {
        private readonly InfolinkDbContext dbContext;

        public GetList(InfolinkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<object> Handle()
        {
            return await dbContext.Set<Subscriber>().
                Select(document => new SubscriberRow
                {
                    Id=document.Id, 
                    Name = document.Name,

                }).ToListAsync();
        }
    }
}
