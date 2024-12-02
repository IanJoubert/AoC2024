using AoC.Common;

namespace AoC.Days
{
    public class Day2 : Day
    {
        private static List<List<int>> ParseInput(List<string> lines)
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
            var counter = 0; // 341
            // 341
            foreach (var report in reports)
            {
                if(Part1Calc(report))
                {
                    counter++;
                }
            }
            val = counter;
        }

        private static bool Part1Calc(List<int> report)
        {
            if (!(report.SequenceEqual(report.OrderBy(x => x)) || report.SequenceEqual(report.OrderByDescending(x => x))))
            {
                return false;
            }

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
            var reports = ParseInput(lines); // 389
            var counter = 0;

            foreach (var report in reports)
            {
                if (Part1Calc(report))
                {
                    counter++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var newList = new List<int>(report);
                        newList.RemoveAt(i);
                        if (Part1Calc(newList))
                        {
                            counter++;
                            break;
                        }
                    }
                }                
            }

            val = counter;
            //foreach (var report in reports)
            //{
            //    var tolerate = 0;
            //    bool? topSign = null;

            //    var i = report.Count - 1;
            //    while (i > 0)
            //    {
            //        var asd = report[i] - report[i - 1];

            //        bool? sign = asd == 0 ? null : asd > 0;
            //        if (topSign == null)
            //        {
            //            topSign = sign;
            //        }
            //        else if (topSign != sign)
            //        {
            //            if (tolerate == 0)
            //            {
            //                tolerate++;

            //                var newList1 = new List<int>(report);
            //                var newList2 = new List<int>(report);

            //                newList1.RemoveAt(i - 1);
            //                newList2.RemoveAt(i);

            //                if (Part1Calc(newList1) || Part1Calc(newList2))
            //                {
            //                    break;
            //                }
            //                else
            //                {
            //                    i--;
            //                    counter--;
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                i--;
            //                counter--;
            //                break;
            //            }
            //        }

            //        var diff = Math.Abs(asd);
            //        if (diff > 3 || diff == 0)
            //        {
            //            if (tolerate == 0)
            //            {
            //                tolerate++;

            //                var newList1 = new List<int>(report);
            //                var newList2 = new List<int>(report);

            //                newList1.RemoveAt(i - 1);
            //                newList2.RemoveAt(i);

            //                if (Part1Calc(newList1) || Part1Calc(newList2))
            //                {
            //                    break;
            //                }
            //                else
            //                {
            //                    i--;
            //                    counter--;
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                i--;
            //                counter--;
            //                break;
            //            }
            //        }
            //        i--;
            //    }
            //}
            //val = counter;
        }
    }
}
