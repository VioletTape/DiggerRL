using System.Linq;
using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Services {
    public class StoreService {
        private ILogger log = Log.ForContext<StoreService>();

        public StoreService() {
            
        }

        public void Handle(DiggerInStore command) {
            var sum = command.Digger.Bag.Sum(i => i.Value);
            command.Digger.Gold += sum;
            command.Digger.Bag.Clear();
        }

        public void Handle(DiggerLeftStore command) {
            
        }

    }
}