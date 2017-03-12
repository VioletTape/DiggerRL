using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Game {
        public Map map;
        public Player Player;

        public Game() {
            map = new Map(new Rule());
            map.GenerateMountain();
            map.GenerateDigger();

            Player = new Player();

            Player.OnMove += OnMove;
        }

        private void OnMove(Point move) {
            map.DiggerPosition += move;
        }
    }
}