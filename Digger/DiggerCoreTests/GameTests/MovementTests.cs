using DiggerCore;
using DiggerCoreTests.TestData;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DiggerCoreTests.GameTests {

    [TestFixture()]
    public class GameInitializationTests {
        private Game game;

        [SetUp]
        public void Init() {
            game = new Game(new TestRules());
        }

        [Test]
        public void testname() {
            
        }
    }
}
