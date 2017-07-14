using DiggerCore;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestExtensions;
using NUnit.Framework;

namespace DiggerCoreTests.Utils {
    [TestFixture(TestOf = typeof(BlockBuilder))]
    public class BlockBuilderTests {
        [Test(Description = "Should Build Some Default Walls")]
        public void ShouldBuildSomeDefaultWalls() {
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

        [Test]
        public void ShouldBuildSurfaceForOneLevel() {
            var map = new Map(new Rule {
                                           MapSize = new Size(3, 1)
                                       });

            new BlockBuilder().BuildSurface(map);

            map.WithRender()
               .Render<SurfaceTile>('X')
               .CompareWith(" X \r\n");
        }

        [Test]
        public void ShouldBuildSurfaceForTwoLevels() {
            var map = new Map(new Rule {
                                           MapSize = new Size(4, 3)
                                       });

            new BlockBuilder().BuildSurface(map);

            map.WithRender()
               .Render<SurfaceTile>('X')
               .CompareWith(" XX \r\n" +
                            " XX \r\n" +
                            "    \r\n");
        }
    }
}
