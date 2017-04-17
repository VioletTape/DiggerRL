using System;
using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Map {
        public readonly Rule Rule;
        public readonly TileArray TileMap;

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
    }
}
