using FluentAssertions;
using NUnit.Framework;

namespace MovementManagerRL.Tests {
    [TestFixture]
    public class WhenRegisterOneTimeActor {
        [Test]
        public void ItShouldReappear() {
            var queue = new ActorQueueManager(10);
            var obj = new GameElement("A", 10);

            // act
            // queue.Add(obj);

            // assert
            for (var i = 0; i < 2; i++) {
                queue.PopNext().Should()
                     .NotBeNull();
            }
        }
    }
}