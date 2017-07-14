using DiggerCore;
using DiggerCore.Tiles;
using DiggerCoreTests.TileArrayTests;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.StructsTests {
    [TestFixture]
    public class TileTests {
        [Test]
        public void ShouldBeClosedByDefault() {
            var tile = new TestTile(TileType.Dirt);

            tile.IsDiscovered
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeAbleToCreateNonDefaultType() {
            var tile = new SurfaceTile();

            tile.Type.Should()
                .Be(TileType.Surface);
        }

        [Test]
        public void DestructableSettings() {
            var tile = new SurfaceTile();
            tile.AllowEntrance()
                .Should()
                .BeTrue();

            var block = new BlockTile();
            block.AllowEntrance()
                 .Should()
                 .BeFalse();
        }
    }
}
