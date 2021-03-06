﻿using SW.Infolink.Domain;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SW.Infolink
{
    class XchangesDueForDelivery : ISpecification<Xchange>
    {
        public XchangesDueForDelivery(DateTime? asOf = null)
        {
            if (asOf == null) asOf = DateTime.UtcNow;

            Criteria = e => e.DeliverOn < asOf
                && e.DeliveredOn == null
                && e.Status == XchangeStatus.Success;
        }

        public Expression<Func<Xchange, bool>> Criteria { get; }

    }
}
