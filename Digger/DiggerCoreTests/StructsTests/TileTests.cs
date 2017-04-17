using DiggerCore;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.StructsTests {
    [TestFixture]
    public class TileTests {
        [Test]
        public void ShouldBeClosedByDefault() {
            var tile = new Tile();

            tile.IsOnMap
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldBeDirtByDefault() {
            var tile = new Tile();

            tile.Type
                .Should()
                .Be(TileType.Dirt);
        }

        [Test]
        public void ShouldBeAbleToCreateNonDefaultType() {
            var tile = new Tile(TileType.Surface);

            tile.Type.Should()
                .Be(TileType.Surface);
        }
    }
}
