using FluentAssertions;
using NUnit.Framework;

namespace MovementManagerRL.Tests {
    [TestFixture]
    public class WhenRegisterPermanentActor {
        [Test]
        public void ItShouldReappear() {
            var queue = new ActorQueueManager(10);
            var obj = new GameElement("A", 10);

            // act
            queue.Register(obj);

            // assert
            for (var i = 0; i < 2; i++) {
                queue.PopNext().Should()
                     .NotBeNull();
            }
        }

        [Test]
        public void TheyShouldAppearAccordingToSpeed() {
            var queue = new ActorQueueManager(10);
            var obj1 = new GameElement("A", 10);
            var obj2 = new GameElement("B", 5);

            // act - order is important
            queue.Register(obj2);
            queue.Register(obj1);

            // assert
            queue.PopNext().Speed.Should().Be(5);
            queue.PopNext().Speed.Should().Be(10);
            queue.PopNext().Speed.Should().Be(5);
            queue.Turn.Should().Be(1);
            // next turn starts
            queue.PopNext().Speed.Should().Be(5);
            queue.Turn.Should().Be(2);
            queue.PopNext().Speed.Should().Be(10);
            queue.PopNext().Speed.Should().Be(5);
        }
    }
}
