namespace AoC.Common
{
    public abstract class Day
    {
        public string Part1(List<string> lines)
        {
            DoPart1(lines, out int val);
            return val.ToString();
        }

        public string Part2(List<string> lines)
        {
            DoPart2(lines, out int val);
            return val.ToString();
        }

        protected virtual List<List<int>> ParseInput(List<string> lines)
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

        protected abstract void DoPart1(List<string> lines, out int val);
        protected abstract void DoPart2(List<string> lines, out int val);
    }
}
