﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace ClientApp
{
    class PublishSubOptions
    {

        [Option(longName: "QueueName", HelpText = "")]
        public String QueueName { get; set; }

        [Option(longName: "UserName", HelpText = "")]
        public String UserName { get; set; }

        [Option(longName: "Password", HelpText = "")]
        public String Password { get; set; }

        [Option(longName: "IpAddress", HelpText = "")]
        public String IpAddress { get; set; }

        [Option(longName: "VirtualHost", HelpText = "")]
        public String VirtualHost { get; set; }

        [Option(longName: "PersistentQueue", HelpText = "")]
        public bool PersistentQueue { get; set; }

        [Option(longName: "PersistentMessages", HelpText = "")]
        public bool PersistentMessages { get; set; }

        [Option(longName: "BindingKey", HelpText = "")]
        public String BindingKey { get; set; }

        [Option(longName: "FilePaths", HelpText = "")]
        public String FilePaths { get; set; }


        [Option(longName: "ConfirmsEnabled", HelpText = "")]
        public String ConfirmsEnabled { get; set; }

        [Option(longName: "MandatoryEnabled", HelpText = "")]
        public String MandatoryEnabled { get; set; }

        [Option(longName:"PublishCount", HelpText = "")]
        public int Count { get; set; }

        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }


    }
}
