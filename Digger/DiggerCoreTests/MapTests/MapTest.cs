using DiggerCore;
using DiggerCoreTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.MapTests {
    [TestFixture]
    [TestOf(typeof(Map))]
    public class MapTest {
        private TestDisplay display;
        private TestRules rules;

        [SetUp]
        public void Init() {
            display = new TestDisplay();

            rules = new TestRules();
            rules.SetSmall();
        }

        [Test]
        public void ShouldGenerateMountain() {
            var map = new Map(rules);
            map.GenerateMountain();

            var render = display.Render(map);
            render.Should()
                  .Be("&_____####\r\n" +
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

        [Test]
        public void ShouldGenerateDigger() {
            var map = new Map(rules);
            map.GenerateMountain();
            map.GenerateDigger();

            var render = display.Render(map);
            render.Should()
                  .Be("______####\r\n" +
                      "&_########\r\n" +
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