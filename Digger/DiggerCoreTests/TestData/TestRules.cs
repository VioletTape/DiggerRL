using DiggerCore;
using DiggerCore.ElementalStructures;

namespace DiggerCoreTests.TestData {
    public class TestRules : Rule {
        public static Size Small = new Size(10,10);

        public void SetSmall() {
            MapSize = Small;
        }
    }
}