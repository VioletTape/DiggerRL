using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class EmptyTile : Tile
    {
        public EmptyTile() : base(TileType.Empty) { }

        public override int StaminaPrice => 2;
        public override bool AllowMovementTo(Direction direction) {
            throw new System.NotImplementedException();
        }

        public override bool AllowEntrance() {
            throw new System.NotImplementedException();
        }
    }
}