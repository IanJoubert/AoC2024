using AoC.Common;

namespace AoC.Days
{
    public class Day4 : Day
    {
        protected override void DoPart1(List<string> lines, out int val)
        {
            string word = "XMAS";
            int wordLength = word.Length;
            int gridSize = lines.Count;

            int count = 0;

            int[][] directions = {
                [0, 1],
                [1, 0],
                [0, -1],
                [-1, 0],
                [1, 1],
                [1, -1],
                [-1, 1],
                [-1, -1]
            };

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    foreach (var direction in directions)
                    {
                        int found = 1;
                        for (int k = 0; k < wordLength; k++)
                        {
                            int newRow = row + k * direction[0];
                            int newCol = col + k * direction[1];

                            if (newRow < 0 || newRow >= gridSize || newCol < 0 || newCol >= gridSize ||
                                lines[newRow][newCol] != word[k])
                            {
                                found = 0;
                                break;
                            }
                        }
                        count += found;
                    }
                }
            }
            val = count;
        }

        protected override void DoPart2(List<string> lines, out int val)
        {
            int gridSize = lines.Count;
            var grid = lines.ToArray();

            int count = 0;

            for (int row = 0; row < gridSize - 2; row++)
            {
                for (int col = 0; col < gridSize - 2; col++)
                {
                    count += CheckXMas(grid, row, col) ? 1 : 0;
                }
            }
            val = count;
        }

        static bool CheckXMas(string[] grid, int row, int col)
        {
            string[][] patterns = {
                ["M", "A", "S", "M", "A", "S"], 
                ["S", "A", "M", "S", "A", "M"],

                ["S", "A", "M", "M", "A", "S"],
                ["M", "A", "S", "S", "A", "M"]
            };

            char[] chars = {
                grid[row][col],
                grid[row + 1][col + 1],
                grid[row + 2][col + 2],
                grid[row + 2][col],
                grid[row + 1][col + 1],
                grid[row][col + 2]
            };

            foreach (var pattern in patterns)
            {
                if (chars[0] == pattern[0][0] && chars[1] == pattern[1][0] && chars[2] == pattern[2][0] &&
                    chars[3] == pattern[3][0] && chars[4] == pattern[4][0] && chars[5] == pattern[5][0])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
