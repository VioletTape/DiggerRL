namespace DiggerCore {
    public class Map {
        public TileArray tileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            tileMap = new TileArray(rule.MapSize);
        }

        public void GenerateMountain() {
            for (var i = 0; i < tileMap.Width - 4; i++) {
                tileMap[0, i] = new Tile(TileType.Air);
            }
            for (var i = 0; i < tileMap.Width - 8; i++) {
                tileMap[1, i] = new Tile(TileType.Air);
            }
        }

        public void GenerateDigger() {
            var digger = new Digger();
            DiggerPosition = new Point(1, 3);
        }

        public string Draw(Point point) {
            if (point == DiggerPosition) {
                return "&";
            }

            return tileMap[point].Type == TileType.Air ? "_" : "#";
        }
    }

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