using System.Linq;
using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Services {
    public class StoreService {
        private ILogger log = Log.ForContext<StoreService>();

        public StoreService() {
            
        }

        public void Handle(DiggerInStore command) {
            var digger = command.Digger;
            digger.Gold += digger.SellAllGems();
        }

        public void Handle(DiggerLeftStore command) {
            
        }

    }
}