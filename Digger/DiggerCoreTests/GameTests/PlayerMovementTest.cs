using DiggerCore;
using DiggerCoreTests.TestData;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture]
    public class PlayerMovementTest {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game(Rules.OneCell);
        }

        [Test]
        public void Player() {
                
        }
    }
}
