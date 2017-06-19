namespace DiggerCore.Commands {
    public class MoveDirectionCommand : ICommand {
        public Direction Direction { get; }

        /// <summary>
        ///     Describe in fact intention of direction
        /// </summary>
        /// <param name="direction"></param>
        public MoveDirectionCommand(Direction direction) {
            Direction = direction;
        }
    }


    public class MoveCommand : ICommand {
        public Direction Direction { get; }
        public Tile ActiveTile { get; }

        /// <summary>
        ///     Direction and target tile of that direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="activeTile"></param>
        public MoveCommand(Direction direction, Tile activeTile) {
            Direction = direction;
            ActiveTile = activeTile;
        }
    }
}
