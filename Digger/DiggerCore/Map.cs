using System;
using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Map {
        public readonly Rule Rule;
        public readonly TileArray TileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            Rule = rule;
            TileMap = new TileArray(rule.MapSize);
        }

        public void GenerateMountain() {
            for (var i = 0; i < TileMap.Width - 4; i++)
                TileMap[0, i] = new Tile(TileType.Surface) {
                                                               IsOnMap = true
                                                           };
            for (var i = 0; i < TileMap.Width - 8; i++)
                TileMap[1, i] = new Tile(TileType.Surface) {
                                                               IsOnMap = true
                                                           };
        }

        public void GenerateDigger() {
            DiggerPosition = new Point(1, 0);
        }

        [Obsolete]
        public string TestDraw(Point point) {
            if (point == DiggerPosition)
                return "&";

            if (TileMap[point].Type == TileType.Surface)
                return "_";

            if (TileMap[point].Type == TileType.Empty)
                return " ";

            return "#";
        }
    }
}
