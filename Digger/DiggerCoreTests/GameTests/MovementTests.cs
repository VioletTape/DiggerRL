using DiggerCore;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.GameTests {
    [TestFixture]
    public class MovementTests {
        private TestDisplay display;
        private TestRules rules;

        [SetUp]
        public void Init() {
            display = new TestDisplay();

            rules = new TestRules();
            rules.SetSmall();
        }

        [Test]
        public void SingleRightMovementTest() {
            var game = new Game(rules);
            game.Player.Move(Player.MoveCommand.Right);

            var render = display.Render(game.map);

            render.Should()
                  .Be("______####\r\n" +
                      "_&########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n");
        }

        [Test]
        public void MultipleRightMovementTest()
        {
            var game = new Game(rules);
            game.Player.Move(Player.MoveCommand.Right);
            game.Player.Move(Player.MoveCommand.Right);
            game.Player.Move(Player.MoveCommand.Right);

            var render = display.Render(game.map);

            render.Should()
                  .Be("______####\r\n" +
                      "__#&######\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n");
        }
    }
}