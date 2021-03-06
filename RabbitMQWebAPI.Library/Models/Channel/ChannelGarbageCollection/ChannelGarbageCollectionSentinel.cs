﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    class ChannelGarbageCollectionSentinel : Sentinel<ChannelGarbageCollection>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelGarbageCollection model = new ChannelGarbageCollection();
            model.fullsweep_after = double.Parse(parametersDictionary["fullsweep_after"].ToString());
            model.max_heap_size = double.Parse(parametersDictionary["max_heap_size"].ToString());
            model.min_bin_vheap_size = double.Parse(parametersDictionary["min_bin_vheap_size"].ToString());
            model.min_heap_size = double.Parse(parametersDictionary["min_heap_size"].ToString());
            model.minor_gcs = double.Parse(parametersDictionary["minor_gcs"].ToString());

            return model;
        }
    }
}
