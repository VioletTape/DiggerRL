namespace DiggerCore.Items.SurfaceItems {
    public class Camp : IItem {
        public void Visit(Digger digger) {
            digger.Stamina = digger.MaxStamina;
        }
    }
}