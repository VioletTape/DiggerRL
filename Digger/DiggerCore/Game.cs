using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Game {
        public Map Map;
        public Player Player;
        public Digger Digger;

        public Game(Rule rule) {
            Map = new Map(rule);
            Map.GenerateMountain();

            Player = new Player();

            Player.OnMove += OnMove;
        }

        private void OnMove(Point move) {
        }
    }
}