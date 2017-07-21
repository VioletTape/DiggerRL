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
            digger.Gold += digger.GemBag.Gems.Sum(i => i.Value);
            digger.GemBag.Clear();
        }

        public void Handle(DiggerLeftStore command) {
            
        }

    }

}