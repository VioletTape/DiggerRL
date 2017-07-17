using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class EmptyTile : Tile
    {
        public EmptyTile() : base(TileType.Empty) { }

        public override int StaminaPrice => 2;
        public override int Density { get; protected set; } = 0;

        public override bool AllowMovementTo(Direction direction) {
            throw new System.NotImplementedException();
        }

        public override bool AllowEntrance(Digger digger) {
            throw new System.NotImplementedException();
        }
    }
}