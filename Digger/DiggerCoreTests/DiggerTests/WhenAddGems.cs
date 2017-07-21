using DiggerCore;
using DiggerCore.Items.CollectableItems;
using DiggerCore.Items.Tools;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.DiggerTests {
    [TestFixture]
    public class WhenAddGems {
        [Test]
        public void ItShouldBePossible() {
            var digger = new Digger();

            digger.GemBag.Add(new Coal());

            digger.GemBag.Gems.Count
                  .Should()
                  .Be(1);
        }

        [Test]
        public void CantAddNullGem() {
            var digger = new Digger();

            digger.GemBag.Add(new NullGem());

            digger.GemBag.Gems.Count
                  .Should()
                  .Be(0);
        }

        [Test]
        public void CantAddMoreThanBagCapacity() {
            var digger = new Digger();
            digger.GemBag.Updgrade(new BagSettings {
                                                       Capacity = 5
                                                   });
            
            digger.GemBag.Add(new Coal());
            digger.GemBag.Add(new Coal());
            digger.GemBag.Add(new Coal());
            digger.GemBag.Add(new Coal());
            digger.GemBag.Add(new Coal());

            digger.GemBag.Add(new Coal());

            digger.GemBag.Gems.Count
                  .Should()
                  .Be(5);
        }
    }
}
