using DiggerCore;
using DiggerCore.Commands;
using DiggerCore.Items.CollectableItems;
using DiggerCore.Services;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.ServiceTests.StoreTests {
    [TestFixture]
    public class WhenSellingGems {
        [Test]
        public void GoldShouldBeSummedFromBag() {
            var digger = new Digger();
            digger.GemBag.Add(new Coal());

            var service = new StoreService();
            service.Handle(new DiggerInStore(digger));

            digger.Gold.Should()
                  .Be(10);
            digger.GemBag.Gems.Should()
                .BeEmpty();
        }
    }
}
