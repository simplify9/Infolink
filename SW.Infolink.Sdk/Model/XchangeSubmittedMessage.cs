﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Infolink
{
    public class XchangeSubmittedMessage
    {
        public int XchangeId { get; set; }
        public int MapperId { get; set; }
        public int HandlerId { get; set; }
        public string InputFileName { get; set; }
        public int SubscriberId { get; set; }
        public IDictionary<string, string>  SubscriberProperties { get; set; }

        //public bool IgnoreSchedule { get; set; }
    }
}
