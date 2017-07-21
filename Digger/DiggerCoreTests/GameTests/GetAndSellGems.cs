using System;
using DiggerCore;
using DiggerCore.ElementalStructures;
using DiggerCore.Items.CollectableItems;
using DiggerCore.Items.SurfaceItems;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TestExtensions;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture]
    [Category("Integration")]
    public class GetAndSellGems {
        private Map map;
        private Game game;
        private MapVisualiser mapVisualiser;

        [SetUp]
        public void Init() {
            var gemFactory = new GemFactory();

            game = new Game();

            map = new Map(Rules.TenCells);

            new BlockBuilder(map)
                    .BuildSurface()
                    .BuildWalls()
                    .BuildEntrance()
                    // core setup
                    .BuildStore(game.Hub)
                    .WithGem(new Point(6,1), gemFactory.Get<Coal>());

            mapVisualiser = map.WithRender()
                               .Render<SurfaceTile>(' ')
                               .Render<DirtTile>('#')
                               .RenderItem<Store>('$')
                               .RenderGem<Coal>('+')
                               .WithDigger();

            Console.WriteLine(mapVisualiser.Print());

            game.SetMap(map);
        }

        [Test]
        public void testname() {
            game.SendDiggerRight();
            game.SendDiggerRight();
            game.SendDiggerRight();
            game.SendDiggerRight();
            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerLeft();
            game.SendDiggerLeft();
            game.SendDiggerLeft();
            game.SendDiggerLeft();
            Console.WriteLine(mapVisualiser.Print());

            game.Digger.Gold
                .Should()
                .Be(10);

            game.EndGame();
        }

    }
}
