using System.Collections.Generic;
using DiggerCore.Commands;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;

namespace DiggerCore {
    public class Map {
        private static readonly Point Left = new Point(0, -1);
        private static readonly Point Right = new Point(0, 1);
        private static readonly Point Up = new Point(-1, 0);
        private static readonly Point Down = new Point(1, 0);

        private static readonly List<Point> Points = new List<Point> {
                                                                         Left
                                                                         , Up
                                                                         , Right
                                                                         , Down
                                                                     };

        public readonly Rule Rule;
        public readonly TileArray TileMap;
        private readonly Point diggerPosition;

        public Map(Rule rule) {
            Rule = rule;
            TileMap = new TileArray(rule.MapSize);
            diggerPosition = rule.DiggerPosition;
        }

        public void GenerateMountain() {
            for (var i = 0; i < TileMap.Width - 4; i++)
                TileMap[0, i] = new SurfaceTile() {
                                                               IsDiscovered = true
                                                           };
            for (var i = 0; i < TileMap.Width - 8; i++)
                TileMap[1, i] = new SurfaceTile() {
                                                               IsDiscovered = true
                                                           };
        }

        public Tile GetTileNextTo(MoveDirectionCommand moveDirectionCommand) {
            return TileMap[diggerPosition + GetPoint(moveDirectionCommand)];
        }

        private static Point GetPoint(MoveDirectionCommand directionCommand) {
            return Points[(int) directionCommand.Direction];
        }
    }
}
