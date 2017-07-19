using System.Xml.Linq;
using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Services {
    public class CampService {
        private ILogger log = Log.ForContext<CampService>();

        public CampService() {
            
        }

        public void Handle(DiggerInCamp command) {}

        public void Handle(DiggerLeftCamp command) {}

    }

    public class StoreService {
        private ILogger log = Log.ForContext<StoreService>();

        public StoreService() {
            
        }

        public void Handle(DiggerInStore command) {}

        public void Handle(DiggerLeftStore command) {}

    }
}
