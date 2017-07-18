using System;
using DiggerCore.Commands;
using Serilog;

namespace DiggerCore.Tiles {
    public class BlockTile : Tile {
        private ILogger log = Log.ForContext<BlockTile>();
        public BlockTile() : base(TileType.Block) { }

        public override int StaminaPrice => 0;
        public override int Density { get; protected set; }

        public override bool AllowMovementTo(Direction direction) {
            var exception = new NotImplementedException("Digger cant stand here");
            log.Error(exception, "{actor} can stand here", "Digger");
            throw exception;
        }

        public override bool AllowEntrance(Digger digger) {
            return false;
        }
    }
}
