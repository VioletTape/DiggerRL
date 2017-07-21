using DiggerCore;
using DiggerCore.Items.CollectableItems;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.DiggerTests {
    [TestFixture]
    public class WhenAddGems {
        [Test]
        public void ItShouldBePossible() {
            var digger = new Digger();

            digger.Add(new Coal());

            digger.Bag.Count
                  .Should()
                  .Be(1);
        }

        [Test]
        public void CantAddNullGem() {
            var digger = new Digger();

            digger.Add(new NullGem());

            digger.Bag.Count
                  .Should()
                  .Be(0);
        }

        [Test]
        public void CantAddMoreThanBagCapacity() {
            var digger = new Digger();

            digger.Add(new Coal());
            digger.Add(new Coal());
            digger.Add(new Coal());
            digger.Add(new Coal());
            digger.Add(new Coal());

            digger.Add(new Coal());

            digger.Bag.Count
                  .Should()
                  .Be(5);
        }
    }
}
