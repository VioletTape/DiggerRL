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

            tile.IsOnMap
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeAbleToCreateNonDefaultType() {
            var tile = new SurfaceTile();

            tile.Type.Should()
                .Be(TileType.Surface);
        }
    }
}
