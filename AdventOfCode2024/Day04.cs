namespace AdventOfCode2024;

public class Day04
{
    public Day04()
    {
        var lines = File.ReadAllLines("Day04.txt");
        // Part1(lines);
        Part2(lines);
    }

    private void Part1(string[] lines)
    {
        var counter = 0;

        // look for:
        // - North East
        // - East
        // - South East
        // - South
        var width = lines[0].Length;
        var height = lines.Length;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var reversed = false;

                switch (lines[y][x])
                {
                    case 'X':
                        break;
                    case 'S':
                        reversed = !reversed;
                        break;
                    default:
                        continue;
                }

                // look North East
                if (y >= 3 && width - x >= 4)
                {
                    if (!reversed)
                    {
                        if (
                            lines[y - 1][x + 1] == 'M' &&
                            lines[y - 2][x + 2] == 'A' &&
                            lines[y - 3][x + 3] == 'S'
                        )
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (
                            lines[y - 1][x + 1] == 'A' &&
                            lines[y - 2][x + 2] == 'M' &&
                            lines[y - 3][x + 3] == 'X'
                        )
                        {
                            counter++;
                        }
                    }
                }

                // look East
                if (width - x >= 4)
                {
                    if (!reversed)
                    {
                        if (
                            lines[y][x + 1] == 'M' &&
                            lines[y][x + 2] == 'A' &&
                            lines[y][x + 3] == 'S'
                        )
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (
                            lines[y][x + 1] == 'A' &&
                            lines[y][x + 2] == 'M' &&
                            lines[y][x + 3] == 'X'
                        )
                        {
                            counter++;
                        }
                    }
                }

                // look South East
                if (height - y >= 4 && width - x >= 4)
                {
                    if (!reversed)
                    {
                        if (
                            lines[y + 1][x + 1] == 'M' &&
                            lines[y + 2][x + 2] == 'A' &&
                            lines[y + 3][x + 3] == 'S'
                        )
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (
                            lines[y + 1][x + 1] == 'A' &&
                            lines[y + 2][x + 2] == 'M' &&
                            lines[y + 3][x + 3] == 'X'
                        )
                        {
                            counter++;
                        }
                    }
                }

                // look South
                if (height - y >= 4)
                {
                    if (!reversed)
                    {
                        if (
                            lines[y + 1][x] == 'M' &&
                            lines[y + 2][x] == 'A' &&
                            lines[y + 3][x] == 'S'
                        )
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (
                            lines[y + 1][x] == 'A' &&
                            lines[y + 2][x] == 'M' &&
                            lines[y + 3][x] == 'X'
                        )
                        {
                            counter++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(counter);
    }

    private void Part2(string[] lines)
    {
        var counter = 0;

        var width = lines[0].Length;
        var height = lines.Length;
        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if (lines[y][x] != 'A') continue;

                if (
                    (
                        (
                            lines[y + 1][x + 1] == 'M' &&
                            lines[y - 1][x - 1] == 'S'
                        ) ||
                        (
                            lines[y + 1][x + 1] == 'S' &&
                            lines[y - 1][x - 1] == 'M'
                        )
                    ) && (
                        (
                            lines[y - 1][x + 1] == 'M' &&
                            lines[y + 1][x - 1] == 'S'
                        ) ||
                        (
                            lines[y - 1][x + 1] == 'S' &&
                            lines[y + 1][x - 1] == 'M'
                        )
                    )
                )
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }
}