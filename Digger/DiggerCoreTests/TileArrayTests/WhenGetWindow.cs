using DiggerCore;
using DiggerCore.ElementalStructures;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.TileArrayTests {
    [TestFixture]
    [TestOf(typeof(TileArray))]
    public class WhenGetWindow {
        [Test]
        public void SizeShouldBeAccordingToSetWindow()
        {
            // arrange
            var tileArray = new TileArray(new Size(2000, 50));
            var offset = new Point(5, 10);
            tileArray.SetWindow(offset);

            // act
            var window = tileArray.GetWindow(new Point(20, 20));

            // assert
            window.Width.Should().Be(offset.Width*2);
            window.Depth.Should().Be(offset.Depth*2);
        }

        [Test]
        public void ShouldRepresentDataFromOriginalMap()
        {   
            // arrange
            var tileArray = new TileArray(new Size(2000, 50));
            var offset = new Point(5, 10);
            tileArray.SetWindow(offset);

            // pre-assert
            tileArray[20 - 5, 20 - 10]
                    .Type
                    .Should()
                    .Be(TileType.Dirt);

            // act
            var window = tileArray.GetWindow(new Point(20, 20));
            window[0,0].Type = TileType.Empty;


            // assert
            tileArray[20 - 5, 20 - 10]
                    .Type
                    .Should()
                    .Be(TileType.Empty);
        }

        [Test]
        public void ShouldProcessEndOfMap() {
            var tileArray = new TileArray(new Size(50, 50));
            tileArray.SetWindow(new Point(5, 10));

            var window = tileArray.GetWindow(new Point(4, 4));
            window[0, 0].Type = TileType.Blacked;
        }
    }
}
