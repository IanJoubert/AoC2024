using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Common;

namespace AoC.Days.Tests
{
    public class CommonTests
    {
        [Fact]
        public void CleanList()
        {
            // Arrange
            var items = new List<string>
            {
                "3   4 ",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };
            var expected = new List<string>
            {
                "3 4",
                "4 3",
                "2 5",
                "1 3",
                "3 9",
                "3 3"
            };

            // Act
            var actual = Sanitizer.CleanList(items);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
