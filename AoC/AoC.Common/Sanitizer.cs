using System.Text.RegularExpressions;

namespace AoC.Common
{
    public class Sanitizer
    {
        public static List<string> CleanList(IEnumerable<string> lines)
        {
            return lines.Select(line =>
            {
                return Regex.Replace(line.Trim(), @"\s+", " ");
            }).ToList();
        }
    }
}
