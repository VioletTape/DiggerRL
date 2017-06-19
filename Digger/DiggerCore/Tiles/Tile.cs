namespace DiggerCore.Tiles {
    public abstract class Tile {
        public TileType Type;
        public bool IsOnMap;

        protected Tile(TileType type) {
            Type = type;
        }

        public abstract int StaminaPrice { get; }
    }
}
