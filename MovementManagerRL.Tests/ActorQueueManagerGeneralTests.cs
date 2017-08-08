using System;
using NUnit.Framework;

namespace MovementManagerRL.Tests {
    [TestFixture]
    public class ActorQueueManagerGeneralTests {
        [Test]
        public void ProcessingTest() {
            var qm = new ActorQueueManager(10);

            var beastA = new GameElement("A", 5);
            var beastB1 = new GameElement("B1", 10);
            var beastB2 = new GameElement("B2", 10);
            var beastB3 = new GameElement("B3", 5);
            var beastC = new GameElement("C", 15);

            qm.Register(beastA);
            qm.Register(beastB1);
            qm.Register(beastB2);
            qm.Register(beastB3);
            qm.Register(beastC);

            for (var i = 0; i < 10000; i++) {
                var next = qm.PopNext();
            }
        }
    }
}