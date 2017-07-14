namespace DiggerCore.ElementalStructures {
    public struct Size {
        public readonly int Depth;
        public readonly int Width;

        public Size(int width, int depth) {
            Depth = depth;
            Width = width;
        }

        public static implicit operator int(Size size) {
            return size.Depth * size.Width;
        }
    }
}