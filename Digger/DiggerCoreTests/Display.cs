using System;
using DiggerCore;

namespace DiggerCoreTests {
    public class Display {
        public Display(Map map) {
            for (int j = 0; j < map.tileMap.Depth; j++) {
                for (int i = 0; i < map.tileMap.Width; i++) {
                    Console.Write(map.Draw(new Point(j,i)));
                }
                Console.WriteLine();
            }
        }
    }
}