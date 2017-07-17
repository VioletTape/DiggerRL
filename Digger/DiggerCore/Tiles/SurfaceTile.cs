using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class SurfaceTile : Tile
    {
        public SurfaceTile() : base(TileType.Surface) { }

        public override int StaminaPrice => 1;
        public override int Density  { get; protected set; } = 0;

        public override bool AllowMovementTo(Direction direction) {
            return direction == Direction.Left || direction == Direction.Right;
        }

        public override bool AllowEntrance(Digger digger) {
            return true;
        }
    }
}