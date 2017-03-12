namespace DiggerCore.ElementalStructures {
    public struct Size {
        public readonly int Depth;
        public readonly int Width;

        public Size(int depth, int width) {
            Depth = depth;
            Width = width;
        }

        public static implicit operator int(Size size) {
            return size.Depth * size.Width;
        }
    }
}