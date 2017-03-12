using DiggerCore;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DiggerCoreTests.DiggerTests {
    [TestFixture]
    public class DiggerDefaultTests {
        [Test]
        public void DefaultStaminaInitialized() {
            var digger = new Digger();

            digger.Stamina.Should()
                  .BeGreaterThan(0);
        }
    }
}