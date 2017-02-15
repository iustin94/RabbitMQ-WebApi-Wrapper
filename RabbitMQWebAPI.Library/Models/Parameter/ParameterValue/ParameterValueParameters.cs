﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Parameter.ParameterValue
{
    public struct ParameterValueParameters
    {
        public string src_uri;
        public string src_queue;
        public string dest_uri;
        public string dest_queue;
        public int prefetch_count;
        public int reconnect_delay;
        public bool add_forward_headers;
        public string ack_mode;
        public string delete_after;

    }
}
