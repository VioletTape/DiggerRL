using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MovementManagerRL.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void testname() {
            var qm = new ActorQueueManager(10);

            var beastA = new BeastA("A", 5);
            var beastB1 = new BeastB("B1", 10);
            var beastB2 = new BeastB("B2", 10);
            var beastC = new BeastC("C", 15);

            qm.Register(beastA);
            qm.Register(beastB1);
            qm.Register(beastB2);
            qm.Register(beastC);

            for (var i = 0; i < 100; i++) {
                var next = qm.PopNext();
                Console.WriteLine(next);
            }
        }

        public class BeastA : IActor {
            public string Name;

            public BeastA(string s, int speed) {
                Name = s;
                Speed = speed;
            }

            public int Speed { get; set; }

            public override string ToString() {
                return "Name " + Name + " Speed " + Speed;
            }
        }

        public class BeastB : IActor {
            public string Name;
            public BeastB(string s, int speed) {
                Name = s;
                Speed = speed;

            }

            public int Speed { get; set; }

            public override string ToString() {
                return "Name " + Name + " Speed " + Speed;
            }
        }

        public class BeastC : IActor {
            public string Name;
            public BeastC(string s, int speed) {
                Name = s;
                Speed = speed;

            }

            public int Speed { get; set; }

            public override string ToString() {
                return "Name " + Name + " Speed " + Speed;
            }
        }
    }
}
