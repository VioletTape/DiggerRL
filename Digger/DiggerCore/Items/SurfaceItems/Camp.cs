﻿using System.Security.Principal;
using DiggerCore.Commands;
using DiggerCore.Services;
using Serilog;

namespace DiggerCore.Items.SurfaceItems {
    public class Camp : IBuilding {
        private readonly CommandHubService service;
        private ILogger log = Log.ForContext<Camp>();

        public Camp(CommandHubService service) {
            this.service = service;
        }

        public void Visit(Digger digger) {
            log.Verbose("{actor} visit {item} with {stamina}", "Digger", "Camp", digger.Stamina);
            digger.Stamina = digger.MaxStamina;

            service.Send(new DiggerInCamp());
        }

        public void LeftOver() {
            log.Verbose("{actor} left {item}", "Digger", "Camp");
            service.Send(new DiggerLeftCamp());
        }
    }
}
