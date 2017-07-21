using System;
using DiggerCore;
using DiggerCore.Commands;
using DiggerCore.Items;
using DiggerCore.Services;
using DiggerCore.Tiles;
using DiggerCore.Utils;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TestExtensions;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture]
    [Category("Integration")]
    public class DiggerVisitsStore {
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
                    .BuildEntrance()
                    .BuildStore(game.Hub);


            mapVisualiser = map.WithRender()
                               .Render<SurfaceTile>('_')
                               .WithDigger();

            Console.WriteLine(mapVisualiser.Print());

            game.SetMap(map);
        }

        [Test]
        public void NoOpeningWithoudDigger() {
            game.Player.OpenStore();

            var service = game.Get<StoreService>();

            service.digger.Should()
                   .BeNull();
           
        }

        [Test]
        public void StoreAvailableOnlyWithDigger() {
            game.SendDiggerLeft();
            game.Player.OpenStore();

            var service = game.Get<StoreService>();

            service.digger.Should()
                   .NotBeNull();
           
        }

        [Test]
        public void StoreAvailableOnlyWithDigger_2() {
            game.SendDiggerLeft();
            game.Player.OpenStore();

            var service = game.Get<StoreService>();

            service.digger.Should()
                   .NotBeNull();

            // act
            game.SendDiggerLeft();

            // assert
            game.Player.OpenStore();
            service.digger.Should()
                   .BeNull();
        }

        [Test]
        public void PlayerBuyItem() {
            // arrange
            game.Digger.Items.Clear();

            game.Digger.Gold = 100;
            game.SendDiggerLeft();
            game.Player.OpenStore();

            // act
            game.Player.BuyItem(new Ladder());

            // assert
            game.Digger.Items.Count
                .Should()
                .Be(1);
        }

        [Test]
        public void PlayerSpendGoldWhenBuyItem() {
            // arrange
            game.Digger.Items.Clear();

            game.Digger.Gold = 100;
            game.SendDiggerLeft();
            game.Player.OpenStore();

            // act
            game.Player.BuyItem(new Ladder());

            // assert
            game.Digger.Gold
                .Should()
                .Be(90);
        }

        [Test]
        public void PlayerCantBuyIfNoMoney() {
            // arrange
            game.Digger.Items.Clear();
            game.Digger.Gold = 0;

            game.SendDiggerLeft();

            game.Player.OpenStore();

            // act
            game.Player.BuyItem(new Ladder());

            // assert
            game.Digger.Items.Count
                .Should()
                .Be(0);
        }

        [Test]
        public void NoPurchaseWithoutDigger() {
            game.Digger.Gold = 100;
            game.Player.OpenStore();

            game.Player.BuyItem(new Ladder());

            // assert
            game.Digger.Items.Count
                .Should()
                .Be(0);
        }
    }
}
