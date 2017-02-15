﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    public static class ChannelGarbageCollectionKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "max_heap_size",
            "min_bin_vheap_size",
            "min_heap_size",
            "fullsweep_after",
            "minor_gcs"
        };
    }
}
