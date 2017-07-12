using DiggerCore.Utils;
using FluentAssertions;

namespace DiggerCoreTests.TestExtensions {
    public static class MapVisualiserExtension
    {
        public static void CompareWith(this MapVisualiser mv, string expectedMap)
        {
            var actualMap = mv.Print();

            actualMap.Should().Be(expectedMap, "\r\nbecause you expects\r\n{0}\tbut actual is\r\n{1}", expectedMap, actualMap);
        }
    }
}