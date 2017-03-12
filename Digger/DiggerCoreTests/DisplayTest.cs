using DiggerCore;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests {
    [TestFixture]
    [TestOf(typeof(Map))]
    public class MapTest {
        private TestDisplay display;
        private TestRules rules;

        [SetUp]
        public void Init() {
            display = new TestDisplay();

            rules = new TestRules();
            rules.SetSmall();
        }

        [Test]
        public void ShouldGenerateMountain() {
            var map = new Map(rules);  
            map.GenerateMountain();

            display.Render(map);
        }

        [Test]
        public void ShouldGenerateDigger() {
            var map = new Map(rules);
            map.GenerateMountain();
            map.GenerateDigger();

            display.Render(map);
        }

        [Test]
        public void MovementTest() {
            var game = new Game();
            game.Player.Move(Player.MoveCommand.Down);

            display.Render(game.map);
        }
    }


}