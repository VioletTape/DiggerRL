using DiggerCore;
using DiggerCore.Utils;

namespace DiggerCoreTests.TestExtensions {
    public static class MapExtension {
        public static MapVisualiser WithRender(this Map map) {
            return new MapVisualiser(map);
        }
    }
}
