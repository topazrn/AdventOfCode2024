namespace AdventOfCode2024;

public class Day06
{
    private char[][] Map;
    private (int x, int y) Guard;
    private List<(int x, int y)> Points = [];

    public Day06()
    {
        Map = File.ReadAllLines("Day06.txt").Select(x => x.ToCharArray()).ToArray();
        // Part1();
        Part2();
    }

    private void Part1()
    {
        for (int y = 0; y < Map.Length; y++)
        {
            for (int x = 0; x < Map[0].Length; x++)
            {
                if (Map[y][x] == '^' || Map[y][x] == '>' || Map[y][x] == 'v' || Map[y][x] == '<')
                {
                    switch (Map[y][x])
                    {
                        case '^':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveUp();
                            goto Foo;
                        case '>':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveRight();
                            goto Foo;
                        case 'v':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveDown();
                            goto Foo;
                        case '<':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveLeft();
                            goto Foo;
                        default:
                            break;
                    }
                }
            }
        }

        Foo:
        var counter = 0;
        for (int y = 0; y < Map.Length; y++)
        {
            for (int x = 0; x < Map[0].Length; x++)
            {
                Console.Write(Map[y][x]);
                if (Map[y][x] == 'X')
                {
                    counter++;
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine(counter);
    }

    private void Part2()
    {
        for (int y = 0; y < Map.Length; y++)
        {
            for (int x = 0; x < Map[0].Length; x++)
            {
                if (Map[y][x] == '^' || Map[y][x] == '>' || Map[y][x] == 'v' || Map[y][x] == '<')
                {
                    switch (Map[y][x])
                    {
                        case '^':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveUp();
                            goto Foo;
                        case '>':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveRight();
                            goto Foo;
                        case 'v':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveDown();
                            goto Foo;
                        case '<':
                            Guard = (x, y);
                            Points.Add((Guard.x, Guard.y));
                            Map[Guard.y][Guard.x] = 'X';
                            MoveLeft();
                            goto Foo;
                        default:
                            break;
                    }
                }
            }
        }

        Foo:
        foreach (var point in Points)
        {
            Console.WriteLine(point.x + ", " + point.y);
        }

        Console.WriteLine(Points.Count);

        for (int i = 0; i < Points.Count; i++)
        {
            for (int j = 1; j <= Points.Count / 4; j++)
            {
                var length = j * 4 - 1;
                if (i + length >= Points.Count) continue;

                // true means next to change is y
                // false means next to change is x
                var xY = i % 2 == 0;

                if (!xY)
                {
                    if (Between(Points[i].x, Points[i + length].x, Points[i + length - 1].x))
                    {
                        Console.WriteLine($"i: {i}, length: {length}, Found x {Points[i].x}, {Points[i + length].y}");
                    }
                }
                else
                {
                    if (Between(Points[i].y, Points[i + length].y, Points[i + length - 1].y))
                    {
                        Console.WriteLine($"i: {i}, length: {length}, Found y {Points[i].x}, {Points[i + length].y}");
                    }
                }
            }
        }

        // 4, 6 | 
        // 4, 1 | 
        // 8, 1 | 
        // 8, 6 | 
        // 2, 6 | 4, 6
        // 2, 4 | 
        // 6, 4 | 
        // 6, 8 | 6, 6
        // 1, 8 | 2, 8 | 4, 8
        // 1, 7 | 
        // 7, 7 | 6, 7
        //      | 7, 8
        // for (int i = 0; i < Points.Count; i++)
        // {
        //     Console.WriteLine(Points[i].x + ", " + Points[i].y);
        //     // if (Points[i])
        //     // {
        //     //     
        //     // }
        // }
    }

    private bool Between(int value, int a, int b)
    {
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);

        return value >= min && value <= max;
    }

    private void MoveUp()
    {
        Map[Guard.y][Guard.x] = 'X';
        if (Guard.y == 0)
        {
            Points.Add((Guard.x, Guard.y));
            return;
        }

        if (Map[Guard.y - 1][Guard.x] == '#')
        {
            Points.Add((Guard.x, Guard.y));
            MoveRight();
        }
        else
        {
            Guard.y--;
            MoveUp();
        }
    }

    private void MoveRight()
    {
        Map[Guard.y][Guard.x] = 'X';
        if (Guard.x == Map[0].Length - 1)
        {
            Points.Add((Guard.x, Guard.y));
            return;
        }

        if (Map[Guard.y][Guard.x + 1] == '#')
        {
            Points.Add((Guard.x, Guard.y));
            MoveDown();
        }
        else
        {
            Guard.x++;
            MoveRight();
        }
    }

    private void MoveDown()
    {
        Map[Guard.y][Guard.x] = 'X';
        if (Guard.y == Map.Length - 1)
        {
            Points.Add((Guard.x, Guard.y));
            return;
        }

        if (Map[Guard.y + 1][Guard.x] == '#')
        {
            Points.Add((Guard.x, Guard.y));
            MoveLeft();
        }
        else
        {
            Guard.y++;
            MoveDown();
        }
    }

    private void MoveLeft()
    {
        Map[Guard.y][Guard.x] = 'X';
        if (Guard.x == 0)
        {
            Points.Add((Guard.x, Guard.y));
            return;
        }

        if (Map[Guard.y][Guard.x - 1] == '#')
        {
            Points.Add((Guard.x, Guard.y));
            MoveUp();
        }
        else
        {
            Guard.x--;
            MoveLeft();
        }
    }
}