using AoC.Common;

namespace AoC.Days
{
    public class Day5 : Day
    {
        protected override void DoPart1(List<string> lines, out int val)
        {
            var total = 0;
            var rules = lines[0..lines.IndexOf("")];
            var updates = lines[(lines.IndexOf("") + 1)..];
            var results = new List<string[]>();
            var lookup = rules.GroupBy(g => g.Split("|")[0]).ToDictionary(x => x.Key, x => x.Select(s => s.Split("|")[1]).ToList());


            foreach (var update in updates)
            {
                var parts = update.Split(",");
                if (DoCheck(parts, lookup))
                {
                    results.Add(parts);
                    total += int.Parse(parts[parts.Length / 2]);
                }
            }
            val = total;
        }

        private bool DoCheck(string[] parts, Dictionary<string, List<string>> lookup)
        {
            for (var i = 0; i < parts.Length; i++)
            {
                for (var j = i + 1; j < parts.Length; j++)
                {
                    if (lookup.TryGetValue(parts[j], out var values2))
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (values2.Contains(parts[i]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        protected override void DoPart2(List<string> lines, out int val)
        {
            var total = 0;
            var rules = lines[0..lines.IndexOf("")];
            var updates = lines[(lines.IndexOf("") + 1)..];
            var results = new List<string[]>();
            var lookup = rules.GroupBy(g => g.Split("|")[0]).ToDictionary(x => x.Key, x => x.Select(s => s.Split("|")[1]).ToList());


            foreach (var update in updates)
            {
                var parts = update.Split(",");
                if (!DoCheck(parts, lookup))
                {
                    FixOrder(ref parts, lookup);
                    results.Add(parts);

                    total += int.Parse(parts[parts.Length / 2]);
                }
            }
            val = total;
        }

        private static void FixOrder(ref string[] parts, Dictionary<string, List<string>> lookup)
        {
            for (var i = 0; i < parts.Length; i++)
            {
                for (var j = i + 1; j < parts.Length; j++)
                {
                    if (lookup.TryGetValue(parts[j], out var values2))
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (values2.Contains(parts[i]))
                        {
                            var temp = parts[i];
                            parts[i] = parts[j];
                            parts[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
