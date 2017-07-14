using System;
using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class BlockTile : Tile
    {
        public BlockTile() : base(TileType.Block) { }

        public override int StaminaPrice => 0;

        public override bool AllowMovementTo(Direction direction) {
            throw new NotImplementedException("Player cant stand here");
        }

        public override bool AllowEntrance() {
            return false;
        }
    }
}