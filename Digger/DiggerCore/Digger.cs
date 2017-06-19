using DiggerCore.Commands;

namespace DiggerCore {
    public class Digger {
        public int Stamina { get; set; }

        public Digger() {
            Stamina = 100;
        }

        public void Move(MoveCommand move) {
            Stamina -= move.ActiveTile.StaminaPrice;
        }
    }
}
