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
            var tileArray = new TileArray(new Size(50, 2000));
            var offset = new Point(10, 5);
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
            var tileArray = new TileArray(new Size(50, 2000));
            var offset = new Point(10, 5);
            tileArray.SetWindow(offset);

            // pre-assert
            tileArray[20 - 10, 20 - 5]
                    .Type
                    .Should()
                    .Be(TileType.Dirt);

            // act
            var window = tileArray.GetWindow(new Point(20, 20));
            window[0,0].Type = TileType.Empty;


            // assert
            tileArray[20 - 10, 20 - 5]
                    .Type
                    .Should()
                    .Be(TileType.Empty);
        }

      
    }
}
