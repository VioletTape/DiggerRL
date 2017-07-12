using DiggerCore;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestExtensions;
using NUnit.Framework;

namespace DiggerCoreTests.Utils {
    [TestFixture]
    public class BlockBuilderTests {
        [Test]
        public void testname() {
            var map = new Map(new Rule {
                                           MapSize = new Size(3, 3)
                                       });

            new BlockBuilder().BuildWalls(map);

            map.WithRender()
               .Render<BlockTile>('X')
               .CompareWith("X X\r\n" +
                            "X X\r\n" +
                            "XXX\r\n");
        }
    }
}
