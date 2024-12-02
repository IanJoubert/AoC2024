using AoC.Common;

namespace AoC.Days
{
    public class Day2 : Day
    {
        private List<List<int>> ParseInput(List<string> lines)
        {
            var values = new List<List<int>>();
            foreach (var line in lines)
            {
                var items = new List<int>();

                foreach (var item in line.Split(" "))
                {
                    items.Add(int.Parse(item));
                }
                values.Add(items);
            }

            return values;
        }

        protected override void DoPart1(List<string> lines, out int val)
        {
            var reports = ParseInput(lines);
            var counter = 0;
            foreach (var report in reports)
            {
                if(IsSafeLevel(report))
                {
                    counter++;
                }
            }
            val = counter;
        }

        private static bool IsSafeLevel(List<int> report)
        {
            // Check ordering from smallest to largest or largest to smallest
            if (!(report.SequenceEqual(report.OrderBy(x => x)) || report.SequenceEqual(report.OrderByDescending(x => x))))
            {
                return false;
            }

            // Check if the difference between each number is less than 3
            for (int i = 0; i < report.Count - 1; i++)
            {
                var diff = Math.Abs(report[i] - report[i + 1]);
                if (diff > 3 || diff == 0)
                {
                    return false;
                }
            }
            return true;
        }

        protected override void DoPart2(List<string> lines, out int val)
        {
            var reports = ParseInput(lines);
            var counter = 0;

            foreach (var report in reports)
            {
                if (IsSafeLevel(report))
                {
                    counter++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var newList = new List<int>(report);
                        newList.RemoveAt(i);
                        if (IsSafeLevel(newList))
                        {
                            counter++;
                            break;
                        }
                    }
                }                
            }

            val = counter;
        }
    }
}
