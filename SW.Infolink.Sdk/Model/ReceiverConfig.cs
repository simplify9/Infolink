﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.Infolink
{
    public class ReceiverConfig
    {
        public string Name { get; set; }
        public int ReceiverId { get; set; }
        public IDictionary<string, string> Properties { get; set; }
        public ICollection<Schedule> Schedules { get;set; }
    }
}
