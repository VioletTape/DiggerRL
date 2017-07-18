using DiggerCore;
using DiggerCore.Commands;
using DiggerCore.Tiles;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.DiggerTests.WhenDiggerMoves {
    [TestFixture(TestOf = typeof(Digger))]
    public class StaminaTests {
        [Test]
        public void StaminaShouldDecrese() {
            var digger = new Digger();
            var initialStamina = digger.Stamina;

            digger.Move(new EmptyTile());

            digger.Stamina
                  .Should()
                  .BeLessThan(initialStamina);
        }
    }
}
