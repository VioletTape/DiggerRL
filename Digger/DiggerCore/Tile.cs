namespace DiggerCore {
    public struct Tile{
        public readonly TileType Type;

        public Tile(TileType type = TileType.Dirt) {
            Type = type;
        }
    }
}