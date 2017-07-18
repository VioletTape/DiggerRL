using System;
using DiggerCore;
using DiggerCore.Items.SurfaceItems;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TestExtensions;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests.SpecialItemTests {
    [TestFixture]
    public class CampTests {
        private Map map;
        private Game game;
        private MapVisualiser mapVisualiser;

        [SetUp]
        public void Init() {
            game = new Game();
            map = new Map(Rules.TenCells);

            new BlockBuilder(map)
                    .BuildSurface()
                    .BuildCamp();


            mapVisualiser = map.WithRender()
                               .Render<SurfaceTile>(' ')
                               .Render<DirtTile>('-')
                               .RenderItem<Camp>('^')
                               .WithDigger();

            Console.WriteLine(mapVisualiser.Print());

            game.SetMap(map);
        }

        [Test]
        public void CampShouldRestoreStamina() {
            game.SendDiggerLeft();
            game.SendDiggerRight();

            game.Digger.Stamina
                .Should()
                .BeLessThan(game.Digger.MaxStamina);

            // act
            game.SendDiggerRight();

            Console.WriteLine(mapVisualiser.Print());
            game.Digger.Stamina
                .Should()
                .Be(game.Digger.MaxStamina);
        }

        [TearDown]
        public void End() {
            game.EndGame();
        }
    }
}
