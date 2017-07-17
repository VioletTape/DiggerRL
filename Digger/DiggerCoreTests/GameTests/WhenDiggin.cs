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

            game = new Game(map);
        }

        [Test]
        public void ItShouldDig() {
            Console.WriteLine(game.Digger);

            game.SendDiggerRight();
            Console.WriteLine(game.Digger);

            game.SendDiggerRight();
            Console.WriteLine(game.Digger);

            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            
            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerRight();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);

            game.SendDiggerDown();
            Console.WriteLine(mapVisualiser.Print());
            Console.WriteLine(game.Digger);
        }
    }
}
