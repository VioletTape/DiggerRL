using DiggerCore;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests {
    [TestFixture]
    public class MapTest {
        [Test]
        public void ShouldGenerateMountain() {
            var map = new Map(new Rule());  
            map.GenerateMountain();

            new Display(map);
        }

        [Test]
        public void ShouldGenerateDigger() {
            var map = new Map(new Rule());
            map.GenerateMountain();
            map.GenerateDigger();

            new Display(map);
        }

        [Test]
        public void testname() {
            var game = new Game();
            game.Player.Move(Player.MoveCommand.Down);

            new Display(game.map);
        }
    }


}