using AoC.Common;

namespace AoC.Days.Tests
{
    public class Day2Tests
    {
        [Fact]
        public void Part1()
        {
            // Arrange
            string expected = "11";
            Day2 day = new();
            var items = new List<string>
            {
                "3   4 ",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };
            var cleanList = Sanitizer.CleanList(items);

            // Act
            var actual = day.Part1(cleanList);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}