using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Map {
        public readonly Rule Rule;
        public readonly TileArray TileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            this.Rule = rule;
            TileMap = new TileArray(rule.MapSize);
        }

        public void GenerateMountain() {
            for (var i = 0; i < TileMap.Width - 4; i++) {
                TileMap[0, i] = new Tile(TileType.Surface);
            }
            for (var i = 0; i < TileMap.Width - 8; i++) {
                TileMap[1, i] = new Tile(TileType.Surface);
            }
        }

        public void GenerateDigger() {
            DiggerPosition = new Point(1, 3);
        }

        public string TestDraw(Point point) {
            if (point == DiggerPosition) {
                return "&";
            }

            if (TileMap[point].Type == TileType.Surface)
                return "_";

            if (TileMap[point].Type == TileType.Empty)
                return " ";

            return "#";
        }
    }
}