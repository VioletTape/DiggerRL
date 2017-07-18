using System;
using DiggerCore;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TestExtensions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture]
    public class WhenDiggin {
        private Map map;
        private Game game;
        private MapVisualiser mapVisualiser;

        [SetUp]
        public void Init() {
            game = new Game();

            map = new Map(Rules.TenCells);

            new BlockBuilder(map)
                    .BuildSurface()
                    .BuildWalls()
                    .BuildEntrance();


            mapVisualiser = map.WithRender()
                               .Render<SurfaceTile>(' ')
                               .Render<DirtTile>('#')
                               .WithDigger();

            Console.WriteLine(mapVisualiser.Print());

            game.SetMap(map);
        }

        [Test]
        public void ItShouldDig() {
            game.SendDiggerRight();
            game.SendDiggerRight();

            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());

            game.EndGame();
        }
    }
}
