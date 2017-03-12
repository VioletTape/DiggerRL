using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class TileArray {
        private readonly Size size;
        private readonly Tile[,] array;

        public Tile this[int depth, int width] {
            get { return array[depth, width]; }
            set { array[depth, width] = value; }
        }

        public Tile this[Point point]
        {
            get { return array[point.Depth, point.Width]; }
            set { array[point.Depth, point.Width] = value; }
        }

        public int Width => size.Width;
        public int Depth => size.Depth;

        public TileArray(Size size) {
            this.size = size;
            array = new Tile[size.Depth, size.Width];
//            for (int i = 0; i < size.Depth; i++) {
//                for (int j = 0; j < size.Width; j++) {
//                    array[i, j] = new Tile();
//                }
//            }
        }

        public TileArray RangeOf(Range range, TileType tileType) {
            return this;
        }
    }
}