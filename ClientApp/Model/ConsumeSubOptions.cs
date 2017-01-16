﻿using System;
using CommandLine;
using CommandLine.Text;


namespace ClientApp.Model
{
  
    class ConsumeSubOptions
    {
        [Option(longName: "QueueName", HelpText = "")]
        public String QueueName { get; set; }

        [Option(longName:"ExchangeName", HelpText = "")]
        public String ExchangeName { get; set; }

        [Option(longName: "UserName", HelpText = "")]
        public String UserName { get; set; }

        [Option(longName: "Password", HelpText = "")]
        public String Password { get; set; }

        [Option(longName: "Ip", HelpText = "")]
        public String Ip { get; set; }

        [OptionArray(longName: "Hosts", HelpText = "")]
        public String[] Hosts{ get; set; }

        [Option(longName: "VirtualHost", HelpText = "")]
        public String VirtualHost { get; set; }

        [Option(longName: "Port", HelpText = "")]
        public int Port { get; set; }

        [Option(longName: "PersistentQueue", HelpText = "Queue persistency setting from publisher.")]
        public bool PersistentQueue { get; set; }

        [Option(longName: "PersistentMessages", HelpText = "Message persistency setting from publisher")]
        public bool PersistentMessages { get; set; }

        [Option(longName: "BindingKey", HelpText = "")]
        public String BindingKey { get; set; }

        [Option(longName: "MessageAcknowledge", HelpText="")]
        public bool MessageAcknowledge { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

    }
}
