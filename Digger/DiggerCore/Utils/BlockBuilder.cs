﻿using DiggerCore.Items.SurfaceItems;
using DiggerCore.Tiles;

namespace DiggerCore.Utils {
    /// <summary>
    ///     Generate limiting walls around map
    /// </summary>
    public class BlockBuilder {
        private readonly Map map;

        public BlockBuilder(Map map) {
            this.map = map;
        }

        public BlockBuilder BuildWalls() {
            var depth = map.TileMap.Depth;
            var width = map.TileMap.Width;

            for (var i = 0; i < depth; i++) {
                map.TileMap[0, i] = new BlockTile();
                map.TileMap[width - 1, i] = new BlockTile();
            }

            for (var i = 1; i < width - 1; i++)
                map.TileMap[i, depth - 1] = new BlockTile();

            return this;
        }

        public BlockBuilder BuildSurface() {
            var depth = map.TileMap.Depth;
            var width = map.TileMap.Width;

            for (var i = 1; i < width - 1; i++)
                map.TileMap[i, 0] = new SurfaceTile();

            if (depth >= 2) {
                for (var i = 1; i < width - 1; i++)
                    map.TileMap[i, 1] = new SurfaceTile();
            }

            return this;
        }

        public BlockBuilder BuildEntrance(int topLevel = 3, int bottomLevel = 5) {
            var depth = map.TileMap.Depth;
            var width = map.TileMap.Width;

            for (var i = width - 2; width - i < topLevel; i--)
                map.TileMap[i, 0] = new DirtTile();

            for (var i = width - 2; width - i < bottomLevel; i--)
                map.TileMap[i, 1] = new DirtTile();

            return this;
        }

        public BlockBuilder BuildCamp() {
            map.TileMap[4,1].SetItem(new Camp());
            return this;
        }

        public BlockBuilder BuildStore() {
            map.TileMap[1,2].SetItem(new Store());
            return this;
        }
    }
}
