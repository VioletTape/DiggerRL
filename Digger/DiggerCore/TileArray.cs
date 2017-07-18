using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;

namespace DiggerCore {
    public class TileArray {
        private readonly Size size;
        private readonly Tile[,] array;

        public Tile this[int width, int depth] {
            get => array[width, depth];
            set => array[width, depth] = value;
        }

        public Tile this[Point point] {
            get => array[point.Width, point.Depth];
            set => array[point.Width, point.Depth] = value;
        }

        public int Width => size.Width;
        public int Depth => size.Depth;

        public TileArray(Size size) {
            this.size = size;
            array = new Tile[size.Width, size.Depth];
            for (int d = 0; d < size.Depth; d++) {
                for (int w = 0; w < size.Width; w++) {
                    array[w, d] = new DirtTile();
                }
            }
        }

        private Size windowSize = new Size(0, 0);
        private Point windowOffset = new Point();

        /// <summary>
        /// Set logical rendering window according to future user-centric position
        /// </summary>
        /// <param name="offset">Describe offset from user in all directions</param>
        public void SetWindow(Point offset) {
            windowOffset = offset;
            windowSize = new Size(offset.Width + offset.Width, offset.Depth + offset.Depth);
        }

        /// <summary>
        /// Get reference to logical window according to hero in the center
        /// </summary>
        /// <param name="center">Hero point as center</param>
        /// <returns></returns>
        public TileArray GetWindow(Point center) {
            var tileArray = new TileArray(windowSize);
            for (int newD = 0, oldD = center.Depth - windowOffset.Depth; newD < windowSize.Depth; newD++, oldD++) {
                for (int newW = 0, oldW = center.Width - windowOffset.Width; newW < windowSize.Width; newW++, oldW++) {
                    if (oldD < 0
                        || oldW < 0) {
                        tileArray[newW, newD] = new EmptyTile {
                                                                  IsDiscovered = false
                                                              };
                    }
                    else {
                        tileArray[newW, newD] = this[oldW, oldD];
                    }
                }
            }
            return tileArray;
        }
    }
}
