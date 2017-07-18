using System.Collections.Generic;
using DiggerCore;
using DiggerCore.Commands;
using DiggerCoreTests.TestData;
using DiggerCoreTests.TileArrayTests;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture(TestOf = typeof(Game))]
    public class PlayerCommandTests {
        private Game game;

        public static IEnumerable<MoveDirectionCommand> Directions() {
            yield return DirectionCommand.Down;
            yield return DirectionCommand.Up;
            yield return DirectionCommand.Left;
            yield return DirectionCommand.Right;
        }

        [SetUp]
        public void Init() {
            var map = new Map(Rules.TenCells);
            var size = map.Rule.MapSize;
            for (var d = 0; d < size.Depth; d++){
                for (var w = 0; w < size.Width; w++) {
                    map.TileMap[w, d] = new TestTile(TileType.Dirt);
                }
            }
            game = new Game();
            game.SetMap(map);
        }

        [Test]
        [TestCaseSource(nameof(Directions))]
        public void PlayerMove(MoveDirectionCommand command) {
            var initialStamina = game.Digger.Stamina;

            game.Player.Send(command);

            game.Digger.Stamina
                .Should()
                .BeLessThan(initialStamina);
        }
    }
}
