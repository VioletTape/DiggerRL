using DiggerCore.Tiles;

namespace DiggerCore.Commands {
    public class MoveTo : ICommand {
        public Tile TargetTile { get; }
        public Digger Digger { get; }
        public Direction Direction { get; }

        public MoveTo(Digger digger, Direction direction, Tile targetTile) {
            Digger = digger;
            TargetTile = targetTile;
            Direction = direction;
        }
    }
}
