using System.Data;

namespace DiggerCore {
    public class Tile{
        public TileType Type;
        public bool IsOnMap;

        public Tile(TileType type = TileType.Dirt) {
            Type = type;
        }
    }

}