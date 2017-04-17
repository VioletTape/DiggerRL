using System;
using System.Text;
using DiggerCore;
using DiggerCore.ElementalStructures;

namespace DiggerCoreTests {
    public class TestDisplay {

        public string Render(Map map) {
            var stringBuilder = new StringBuilder(map.Rule.MapSize);

            for (int j = 0; j < map.TileMap.Depth; j++) {
                for (int i = 0; i < map.TileMap.Width; i++) {
                    var tile = map.TestDraw(new Point(j,i));
                    stringBuilder.Append(tile);
                    Console.Write(tile);
                }
                Console.WriteLine();
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }


    }
}