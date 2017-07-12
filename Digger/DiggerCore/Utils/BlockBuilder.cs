using DiggerCore.Tiles;

namespace DiggerCore.Utils {
    /// <summary>
    ///     Generate limiting walls around map
    /// </summary>
    public class BlockBuilder {
        public Map BuildWalls(Map map) {
            var depth = map.TileMap.Depth;
            var width = map.TileMap.Width;

            for (var i = 0; i < depth; i++) {
                map.TileMap[0, i] = new BlockTile();
                map.TileMap[width - 1, i] = new BlockTile();
            }

            for (var i = 1; i < width-1; i++)
                map.TileMap[i, depth-1] = new BlockTile();

            return map;
        }
    }
}
