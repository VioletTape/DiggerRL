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
            game = new Game(new TestRule10Cell());
        }

        [Test]
        public void PlayerMove() {
            var initialStamina = game.Digger.Stamina;

            game.Player.Send(new MoveDirectionCommand(Direction.Right));

            game.Digger.Stamina
                .Should()
                .BeLessThan(initialStamina);
        }
    }
}
