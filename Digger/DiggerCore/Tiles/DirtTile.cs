using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class DirtTile : Tile {
        public DirtTile() : base(TileType.Dirt) { }

        public override int StaminaPrice => 4;
        public override bool AllowMovementTo(Direction direction) {
            throw new System.NotImplementedException();
        }

        public override bool AllowEntrance() {
            throw new System.NotImplementedException();
        }
    }
}