using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC.Days
{
    public class Day3 : Day
    {
        protected override void DoPart1(List<string> lines, out int val)
        {
            var total = 0;
            string pattern = @"mul\((\d+),\s*(\d+)\)";

            foreach (var line in lines)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                List<(int x, int y)> results = [];

                foreach (Match match in matches)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    results.Add((x, y));
                }

                foreach (var (x, y) in results)
                {
                    total += x * y;
                }
            }
            val = total;

        }

        protected override void DoPart2(List<string> lines, out int val)
        {
            var total = 0;
            var input = string.Join(" ", lines);
            string pattern = @"mul\((\d+),\s*(\d+)\)";

            var linesx = new List<string>();
            var items = input.Split("do()");

            var dos = items.Select(value => "do()" + value).ToList();

            foreach (var item in dos)
            {
                var itemsdont = item.Split("don't()");
                linesx.AddRange(itemsdont);
            }

            var itemsToCheck = linesx.Where(x => x.StartsWith("do()")).ToList();

            foreach (var line in itemsToCheck)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                List<(int x, int y)> results = [];

                foreach (Match match in matches)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    results.Add((x, y));
                }

                foreach (var (x, y) in results)
                {
                    total += x * y;
                }
            }

            val = total;
        }
    }
}
