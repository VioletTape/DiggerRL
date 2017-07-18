using System;
using DiggerCore;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TestExtensions;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests.MovementTests {
    [TestFixture]
    [Category("GeneralGameRule")]
    public class OnSurface {
        private Map map;
        private Game game;

        [SetUp]
        public void Init() {
            game = new Game();
            map = new Map(Rules.TenCells);

            new BlockBuilder(map)
                    .BuildSurface()
                    .BuildWalls()
                    .BuildEntrance();


            var script = map.WithRender()
                            .Render<SurfaceTile>(' ')
                            .Render<DirtTile>('#')
                            .WithDigger()
                            .Print();

            Console.WriteLine(script);

            game.SetMap(map);
        }

        [Test]
        public void CanMoveLeft() {
            var expectedPosition = map.DiggerPosition.StepLeft();

            // act
            game.SendDiggerLeft();

            // assert 
            map.DiggerPosition
               .Should()
               .Be(expectedPosition);
        }

        [Test]
        public void CanMoveRight() {
            var expectedPosition = map.DiggerPosition.StepRight();

            // act
            game.SendDiggerRight();

            // assert 
            map.DiggerPosition
               .Should()
               .Be(expectedPosition);
        }

        [Test]
        public void CantDigDown() {
            var initPosition = map.DiggerPosition;

            // act
            game.SendDiggerDown();

            // assert 
            map.DiggerPosition
               .Should()
               .Be(initPosition);
        }

        [Test]
        public void CantClimbUp() {
            var initPosition = map.DiggerPosition;

            // act
            game.SendDiggerUp();

            // assert 
            map.DiggerPosition
               .Should()
               .Be(initPosition);
        }
    }
}
