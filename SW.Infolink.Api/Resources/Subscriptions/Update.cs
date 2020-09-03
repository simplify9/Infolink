﻿using SW.EfCoreExtensions;
using SW.Infolink.Domain;
using SW.Infolink.Model;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Infolink.Api.Resources.Subscribers
{
    class Update : ICommandHandler<int, SubscriptionConfig>
    {
        private readonly InfolinkDbContext dbContext;

        public Update(InfolinkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async public Task<object> Handle(int key, SubscriptionConfig model)
        {
            var entity = await dbContext.FindAsync<Subscription>(key);

            dbContext.Entry(entity).SetProperties(model);

            var updatedSchedules = model.Schedules.Select(dto => new Schedule((Recurrence)dto.Recurrence, dto.On, dto.Backwards)).ToList();
            entity.Schedules.Update(updatedSchedules);

            await dbContext.SaveChangesAsync(); 
            return null;
        }
    }
}