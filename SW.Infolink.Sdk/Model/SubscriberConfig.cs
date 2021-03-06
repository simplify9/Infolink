﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.Infolink
{
    public class SubscriberConfig
    {
        public string Name { get; set; }
        public int KeySetId { get; set; }
        public int DocumentId { get; set; }
        public int HandlerId { get; set; }
        public int MapperId { get; set; }
        public bool Temporary { get; set; }
        public bool Aggregate { get; set; }
        public IDictionary<string, string> Properties { get; set; }
        public IDictionary<string, string> DocumentFilter { get; set; }
        public bool Inactive { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public int ResponseSubscriberId { get; set; }

    }
}
