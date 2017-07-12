using DiggerCore;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {

    [TestFixture(TestOf = typeof(Game))]
    public class GameInitializationTests {
        private Game game;

        [SetUp]
        public void Init() {
            game = new Game(new TestRule10Cell());
        }

        [Test]
        public void PlayerInitialized() {
            game.Player.Should()
                .NotBeNull();
        }

        [Test]
        public void ShouldSetDiggerPosition() {
//            game.Digger

            Assert.Fail();
        }

    }
}
