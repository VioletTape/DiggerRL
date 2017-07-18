using Serilog;

namespace DiggerCore.Items.SurfaceItems {
    public class Camp : IItem {
        private ILogger log = Log.ForContext<Camp>();

        public void Visit(Digger digger) {
            log.Verbose("{actor} visit {item} with {stamina}", "Digger", "Camp", digger.Stamina);
            digger.Stamina = digger.MaxStamina;
        }
    }
}
