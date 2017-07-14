using System.Collections.Generic;
using DiggerCore;
using DiggerCore.Commands;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture(TestOf = typeof(Game))]
    public class PlayerCommandTests {
        private Game game;

        [SetUp]
        public void Init() {
            game = new Game(Rules.TenCells);
        }

        public static IEnumerable<MoveDirectionCommand> Directions() {
            yield return DirectionCommand.Down;
            yield return DirectionCommand.Up;
            yield return DirectionCommand.Left;
            yield return DirectionCommand.Right;
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
