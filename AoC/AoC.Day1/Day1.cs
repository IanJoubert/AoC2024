using AoC.Common;

namespace AoC.Days
{
    public class Day1 : Day
    {
        private static Tuple<List<int>, List<int>> ParseInput(List<string> lines)
        {
            var leftVals = new List<int>();
            var rightVals = new List<int>();
            foreach (var line in lines)
            {
                var items = line.Split(" ");

                leftVals.Add(int.Parse(items[0]));
                rightVals.Add(int.Parse(items[1]));
            }

            leftVals.Sort((a, b) => a.CompareTo(b));
            rightVals.Sort((a, b) => a.CompareTo(b));

            return new Tuple<List<int>, List<int>>(leftVals, rightVals);
        }

        protected override void DoPart1(List<string> lines, out int val)
        {
            var sum = 0;

            var lists = ParseInput(lines);
            for (int i = 0; i < lists.Item1.Count; i++)
            {
                sum += Math.Abs(lists.Item1[i] - lists.Item2[i]);
            }

            val = sum;
        }

        protected override void DoPart2(List<string> lines, out int val)
        {
            var sum = 0;

            var lists = ParseInput(lines);

            var counts = lists.Item2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            foreach (var item in lists.Item1)
            {
                counts.TryGetValue(item, out var count);
                sum += item * count;
            }

            val = sum;
        }
    }
}
