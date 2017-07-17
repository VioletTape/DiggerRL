using System.Collections.Generic;
using DiggerCore.Commands;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;

namespace DiggerCore {
    public class Map {
        private static readonly Point Left = new Point(-1, 0);
        private static readonly Point Right = new Point(1, 0);
        private static readonly Point Up = new Point(0, -1);
        private static readonly Point Down = new Point(0, 1);

        private static readonly List<Point> Points = new List<Point> {
                                                                         Left
                                                                         , Up
                                                                         , Right
                                                                         , Down
                                                                     };

        public readonly Rule Rule;
        public readonly TileArray TileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            Rule = rule;
            TileMap = new TileArray(rule.MapSize);
            DiggerPosition = rule.DiggerPosition;
        }

        public Tile GetCurrentTile() {
            return TileMap[DiggerPosition];
        }

        public Tile GetTileNextTo(MoveDirectionCommand moveDirectionCommand) {
            return TileMap[DiggerPosition + GetPoint(moveDirectionCommand)];
        }

        private static Point GetPoint(MoveDirectionCommand directionCommand) {
            return Points[(int) directionCommand.Direction];
        }

        public void MoveDigger(MoveCommand moveCommand) {
            DiggerPosition += Points[(int) moveCommand.Direction];
        }
    }
}
