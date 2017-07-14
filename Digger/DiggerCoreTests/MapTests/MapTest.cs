using DiggerCore;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.MapTests {
    [TestFixture]
    [TestOf(typeof(Map))]
    public class MapTest {
        private TestDisplay display;
        private Rule rules;

        [SetUp]
        public void Init() {
            display = new TestDisplay();

            rules = Rules.TenCells;
        }

        [Test]
        public void ShouldGenerateMountain() {
            var map = new Map(rules);
            map.GenerateMountain();

            var render = display.Render(map);
            render.Should()
                  .Be("______####\r\n" +
                      "__########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n" +
                      "##########\r\n");
        }
    }
}