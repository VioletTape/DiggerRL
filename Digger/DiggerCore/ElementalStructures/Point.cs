namespace DiggerCore.ElementalStructures {
    public struct Point
    {
        public readonly int Depth;
        public readonly int Width;

        public Point(int depth, int width)
        {
            Depth = depth;
            Width = width;
        }

        public bool Equals(Point other) {
            return Depth == other.Depth && Width == other.Width;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Depth * 397) ^ Width;
            }
        }

        public static bool operator ==(Point x, Point y) {
            return x.Equals(y);
        }

        public static bool operator !=(Point x, Point y) {
            return !(x == y);
        }

        public static Point operator +(Point x, Point y) {
            return new Point(x.Depth + y.Depth, x.Width + y.Width);
        }
    }
}