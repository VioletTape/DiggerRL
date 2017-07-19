using DiggerCore.Commands;

namespace DiggerCore.Items.SurfaceItems {
    public class Store : IItem {
        public Store(CommandHubService service) { }
        public void Visit(Digger digger) { }
        public void LeftOver() {
            
        }
    }
}
