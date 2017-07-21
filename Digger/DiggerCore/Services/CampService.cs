using System.Xml.Linq;
using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Services {
    public class CampService : IService{
        private ILogger log = Log.ForContext<CampService>();
        private bool enableService;

        public CampService() {
            enableService = false;
        }

        public void Handle(DiggerInCamp command) {
            enableService = true;
        }

        public void Handle(DiggerLeftCamp command) {
            enableService = false;
        }

    }
}
