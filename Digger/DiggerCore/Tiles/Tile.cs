using System;
using DiggerCore.Commands;
using DiggerCore.Items;

namespace DiggerCore.Tiles {
    public abstract class Tile {
        public IItem Item { get; private set; } 

        public TileType Type;

        // Is tile discovered by player for mapping purposes
        public bool IsDiscovered;

        protected Tile(TileType type) {
            Type = type;
            Item = new NullItem();
        }

        public virtual int StaminaPrice => 1;
        public abstract int Density { get; protected set; }

        public abstract bool AllowMovementTo(Direction direction);
        public abstract bool AllowEntrance(Digger digger);

        public void SetItem(IItem item) {
            Item = item;
        }

        public override string ToString() {
            return "{\"Type\":\"" + Type + "\", \"Density\":" + Density + "}";
//            return "{\"Type\":\"" + Type + "\", \"StaminaPrice\":" + StaminaPrice + ", \"Density\":" + Density + "}";
        }
    }
}
