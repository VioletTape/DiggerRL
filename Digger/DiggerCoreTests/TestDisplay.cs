using System;
using System.Text;
using DiggerCore;
using DiggerCore.Tiles;

namespace DiggerCoreTests {
    public class TestDisplay {
        public string Render(Map map) {
            var stringBuilder = new StringBuilder(map.Rule.MapSize);

            for (var j = 0; j < map.TileMap.Depth; j++) {
                for (var i = 0; i < map.TileMap.Width; i++) {
                    var tile = TestDraw(map.TileMap[j, i]);
                    stringBuilder.Append(tile);
                    Console.Write(tile);
                }
                Console.WriteLine();
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        public string TestDraw(Tile tile) {
            if (tile.Type == TileType.Surface) {
                return "_";
            }

            if (tile.Type == TileType.Empty) {
                return " ";
            }

            return "#";
        }
    }
}
