using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Game {
        public Map map;
        public Player Player;
        public Digger digger;

        public Game() {
            var rule = new Rule();
            map = new Map(rule);
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