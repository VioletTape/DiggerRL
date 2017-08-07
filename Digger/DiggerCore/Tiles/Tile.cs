using DiggerCore.Commands;
using DiggerCore.Items;
using DiggerCore.Items.CollectableItems;
using Serilog;

namespace DiggerCore.Tiles {
    public abstract class Tile {
        private readonly ILogger log = Log.ForContext<Tile>();

        public IBuilding Building { get; private set; }
        public ICollectable Gem = GemFactory.Null;

        public TileType Type;

        // Is tile discovered by player for mapping purposes
        public bool IsDiscovered;

        protected Tile(TileType type) {
            Type = type;
            Building = new NullBuilding();
        }

        public virtual int StaminaPrice => 1;

        public abstract int Density { get; protected set; }

        public bool MoveFromInto(Direction direction) {
            Building.LeftOver();
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
            Building.Visit(digger);

            digger.GemBag.Add(Gem);
        }

        public abstract bool AllowMovementFrom(Direction direction);
        public abstract bool AllowEntrance(Digger digger);

        public void SetItem(IBuilding building) {
            Building = building;
        }

        public override string ToString() {
            return "{\"Type\":\"" + Type + "\", \"Density\":" + Density + "}";
            //            return "{\"Type\":\"" + Type + "\", \"StaminaPrice\":" + StaminaPrice + ", \"Density\":" + Density + "}";
        }
    }
}
