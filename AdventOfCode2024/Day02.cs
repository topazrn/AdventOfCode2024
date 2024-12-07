namespace AdventOfCode2024;

public class Day02
{
    public Day02()
    {
        var lines = File.ReadAllLines("Day02.txt");
        var reports = lines.Select(line => line.Split(" ").Select(int.Parse).ToArray()).ToArray();

        Console.WriteLine(Part1(reports));
        Console.WriteLine(Part2(reports));
    }

    private int Part1(int[][] reports)
    {
        var safe = 0;
        foreach (var report in reports)
        {
            var increasing = false;
            var decreasing = false;
            var gradual = true;
            for (int i = 1; i < report.Length; i++)
            {
                var diff = report[i] - report[i - 1];
                if (diff >= 1)
                {
                    increasing = true;
                    if (diff > 3) gradual = false;
                }
                else if (diff <= -1)
                {
                    decreasing = true;
                    if (diff < -3) gradual = false;
                }
                else
                {
                    gradual = false;
                }
            }

            if ((increasing ^ decreasing) && gradual)
            {
                safe++;
            }
        }

        return safe;
    }

    private int Part2(int[][] reports, bool dampener = true)
    {
        var safe = 0;
        foreach (var report in reports)
        {
            var increasing = false;
            var decreasing = false;
            var gradual = true;
            for (int i = 1; i < report.Length; i++)
            {
                var diff = report[i] - report[i - 1];
                if (diff >= 1)
                {
                    increasing = true;
                    if (diff > 3) gradual = false;
                }
                else if (diff <= -1)
                {
                    decreasing = true;
                    if (diff < -3) gradual = false;
                }
                else
                {
                    gradual = false;
                }
            }

            if ((increasing ^ decreasing) && gradual)
            {
                if (dampener) Console.WriteLine(string.Join(", ", report));
                safe++;
            }
            else if (dampener)
            {
                var possibilities = new int[report.Length][];
                for (int j = 0; j < possibilities.Length; j++)
                {
                    var r = report.ToList();
                    r.RemoveAt(j);
                    possibilities[j] = r.ToArray();
                }

                if (Part2(possibilities, false) > 0)
                {
                    Console.WriteLine(string.Join(", ", report));
                    safe++;
                }
            }
        }

        return safe;
    }

    // private int Part2(int[][] reports)
    // {
    //     var safe = 0;
    //     foreach (var report in reports)
    //     {
    //         var increasing = false;
    //         var decreasing = false;
    //         var gradual = new bool[report.Length - 1];
    //         for (int i = 1; i < report.Length; i++)
    //         {
    //             var diff = report[i] - report[i - 1];
    //             if (diff >= 1)
    //             {
    //                 increasing = true;
    //                 gradual[i - 1] = !(diff > 3);
    //             }
    //             else if (diff <= -1)
    //             {
    //                 decreasing = true;
    //                 gradual[i - 1] = !(diff < -3);
    //             }
    //             else
    //             {
    //                 gradual[i - 1] = false;
    //             }
    //         }
    //
    //         if ((increasing ^ decreasing) && Dampener(gradual, report))
    //         {
    //             safe++;
    //             Console.WriteLine(string.Join(", ", report));
    //         }
    //     }
    //
    //     return safe;
    // }
    //
    // private bool Dampener(bool[] gradual, int[] report)
    // {
    //     var first = Array.IndexOf(gradual, false);
    //     var last = Array.LastIndexOf(gradual, false);
    //     switch (last - first)
    //     {
    //         case < 2:
    //             var a = report.ToList();
    //             a.RemoveAt(first);
    //             return true;
    //         case > 2:
    //             return false;
    //         case 2:
    //             var r = report.ToList();
    //             r.RemoveAt(last);
    //             return Part1([r.ToArray()]) == 1;
    //     }
    // }
}