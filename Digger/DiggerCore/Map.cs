using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Map {
        public TileArray tileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            tileMap = new TileArray(rule.MapSize);
        }

        public void GenerateMountain() {
            for (var i = 0; i < tileMap.Width - 4; i++) {
                tileMap[0, i] = new Tile(TileType.Surface);
            }
            for (var i = 0; i < tileMap.Width - 8; i++) {
                tileMap[1, i] = new Tile(TileType.Surface);
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

            if (tileMap[point].Type == TileType.Surface)
                return "_";

            if (tileMap[point].Type == TileType.Empty)
                return " ";

            return "#";
        }
    }
}