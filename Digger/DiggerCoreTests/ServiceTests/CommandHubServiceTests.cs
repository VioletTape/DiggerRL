using DiggerCore.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.ServiceTests {
    [TestFixture]
    public class CommandHubServiceTests {
        [Test]
        public void testname() {
            var service = new CommandHubService();
            var dumbService = new DumbService();

            // act 
            service.Subscribe<Something>(dumbService.Do);
            service.Handle(new Something());

            dumbService.Done
                       .Should()
                       .BeTrue();
        }

        internal class DumbService {
            public bool Done; 
            public void Do(Something smth) {
                Done = true;
            }
        }

        internal class Something : ICommand { }
    }
}
