using System.Data;

namespace DiggerCore {
    public class Tile{
        public readonly TileType Type;
        public bool IsOnMap;

        public Tile(TileType type = TileType.Dirt) {
            Type = type;
        }
    }

}