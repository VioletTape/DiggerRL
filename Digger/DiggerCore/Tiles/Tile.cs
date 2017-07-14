using System;
using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public abstract class Tile {
        public TileType Type;

        // Is tile discovered by player for mapping purposes
        public bool IsDiscovered;

        protected Tile(TileType type) {
            Type = type;
        }

        public abstract int StaminaPrice { get; }

        [Obsolete("Move to AllowEntrance")]
        public virtual bool IsDestructale => true;

        public abstract bool AllowMovementTo(Direction direction);
        public abstract bool AllowEntrance();
    }
}
