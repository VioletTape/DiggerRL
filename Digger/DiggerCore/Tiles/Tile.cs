using DiggerCore.Commands;
using DiggerCore.Items;
using DiggerCore.Items.CollectableItems;
using Serilog;

namespace DiggerCore.Tiles {
    public abstract class Tile {
        private readonly ILogger log = Log.ForContext<Tile>();
        public IItem Item { get; private set; }
        public ICollectable Gem = GemFactory.Null;

        public TileType Type;

        // Is tile discovered by player for mapping purposes
        public bool IsDiscovered;

        protected Tile(TileType type) {
            Type = type;
            Item = new NullItem();
        }

        public virtual int StaminaPrice => 1;
        public abstract int Density { get; protected set; }

        public bool MoveFromInto(Direction direction) {
            Item.LeftOver();
            return AllowMovementFrom(direction);
        }

        public bool CanVisit(Digger digger) {
            var res = AllowEntrance(digger);
            return res;
        }

        public void Visit(Digger digger) {
            digger.Stamina -= StaminaPrice;
            log.Verbose("Stamina reduced on {staminaPrice}", StaminaPrice);
            log.Verbose("{actor} moved, stamina left {stamina}", "Digger", digger.Stamina);
            Item.Visit(digger);

            digger.Add(Gem);
        }

        public abstract bool AllowMovementFrom(Direction direction);
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
