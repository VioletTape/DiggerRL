namespace DiggerCore.Tiles {
    public abstract class Tile {
        public TileType Type;

        // Is tile discovered by player
        public bool IsDiscovered;

        protected Tile(TileType type) {
            Type = type;
        }

        public abstract int StaminaPrice { get; }
    }
}
