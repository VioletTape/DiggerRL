using FluentAssertions;
using NUnit.Framework;

namespace MovementManagerRL.Tests {
    [TestFixture]
    public class WhenRegisterOneTimeActor {
        [Test]
        public void ItShouldNotReappear() {
            var queue = new ActorQueueManager(10);
            var obj = new GameElement("A", 10);

            // act
            queue.Add(obj);

            // assert
            queue.PopNext().Should().NotBeNull();
            queue.PopNext().Should().BeNull();
        }
    }
}
