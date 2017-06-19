using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class TileArray {
        private readonly Size size;
        private readonly Tile[,] array;

        public Tile this[int depth, int width] {
            get => array[depth, width];
            set => array[depth, width] = value;
        }

        public Tile this[Point point]
        {
            get => array[point.Depth, point.Width];
            set => array[point.Depth, point.Width] = value;
        }

        public int Width => size.Width;
        public int Depth => size.Depth;

        public TileArray(Size size) {
            this.size = size;
            array = new Tile[size.Depth, size.Width];
            for (int i = 0; i < size.Depth; i++) {
                for (int j = 0; j < size.Width; j++) {
                    array[i,j] = new Tile();
                }
            }
        }

        private Size windowSize = new Size(0,0);
        private Point windowOffset = new Point();
        /// <summary>
        /// Set logical rendering window according to future user-centric position
        /// </summary>
        /// <param name="offset">Describe offset from user in all directions</param>
        public void SetWindow(Point offset) {
            windowOffset = offset;
            windowSize = new Size(offset.Depth+offset.Depth, offset.Width+offset.Width);
        }

        /// <summary>
        /// Get reference to logical window according to hero in the center
        /// </summary>
        /// <param name="center">Hero point as center</param>
        /// <returns></returns>
        public TileArray GetWindow(Point center) {
            var tileArray = new TileArray(windowSize);
            for (int newD = 0, oldD = center.Depth-windowOffset.Depth; 
                     newD < windowSize.Depth;
                     newD++, oldD++) {
                for (int newW = 0, oldW = center.Width - windowOffset.Width; 
                         newW < windowSize.Width; 
                         newW++, oldW++) {
                    if (oldD < 0
                        || oldW < 0) {
                        tileArray[newD, newW] = new Tile(TileType.Blacked);
                    }
                    else {
                        tileArray[newD, newW] = this[oldD, oldW];
                    }
                }
            }
            return tileArray;
        }
    }
}