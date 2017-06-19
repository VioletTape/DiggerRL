using DiggerCore;
using DiggerCore.ElementalStructures;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.TileArrayTests {
    [TestFixture]
    [TestOf(typeof(TileArray))]
    public class TileArrayTests {
        [Test]
        public void ShouldCreateDefaultTypeDirt() {
            var tileArray = new TileArray(new Size(100, 100));

            tileArray[1, 1]
                    .Should()
                    .NotBeNull();

            tileArray[1, 1]
                    .Type
                    .Should()
                    .Be(TileType.Dirt);
        }

        [Test]
        public void CreateTest() {
            var tileArray = new TileArray(new Size(2000, 50));

            tileArray[1, 1]
                    .Should()
                    .NotBeNull();

            tileArray[1, 1]
                    .Type
                    .Should()
                    .Be(TileType.Dirt);
        }

       


    }
}
