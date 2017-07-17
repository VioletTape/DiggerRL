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

        public abstract bool AllowMovementTo(Direction direction);
        public abstract bool AllowEntrance();
    }
}
