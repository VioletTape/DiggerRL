using DiggerCore.ElementalStructures;

namespace DiggerCoreTests.TestExtensions {
    public static class PointExtension {
        public static Point StepLeft(this Point point) {
            return point + new Point(-1, 0);
        }

        public static Point StepRight(this Point point) {
            return point + new Point(1, 0);
        }

        public static Point StepUp(this Point point) {
            return point + new Point(0, -1);
        }

        public static Point StepDown(this Point point) {
            return point + new Point(0, 1);
        }
    }
}