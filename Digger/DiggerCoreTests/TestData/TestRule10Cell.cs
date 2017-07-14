using DiggerCore;
using DiggerCore.ElementalStructures;

namespace DiggerCoreTests.TestData {
    public class TestRule10Cell : Rule {

        public TestRule10Cell() {
            MapSize = new Size(10, 10);
            DiggerPosition = new Point(3, 1);
        }
    }

    public class Test1CellMap : Rule {
        public Test1CellMap() {
            MapSize = new Size(1, 1);
            DiggerPosition = new Point(0, 0);
        }
    }

    public static class Rules {
        public static Rule OneCell => new Test1CellMap();
        public static Rule TenCells => new TestRule10Cell();
        
    }
}