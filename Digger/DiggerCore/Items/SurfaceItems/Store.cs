using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Items.SurfaceItems {
    public class Store : IBuilding {
        private readonly CommandHubService service;
        private ILogger log = Log.ForContext<Camp>();

        public Store(CommandHubService service) {
            this.service = service;
        }

        public void Visit(Digger digger) {
            log.Verbose("{actor} visit {item} with {stamina}", "Digger", "Store", digger.Stamina);

            service.Handle(new DiggerInStore(digger));
        }
        public void LeftOver() {
            log.Verbose("{actor} left {item}", "Digger", "Store");
            service.Handle(new DiggerLeftStore());
            
        }
    }
}
