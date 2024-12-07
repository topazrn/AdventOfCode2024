namespace AdventOfCode2024;

public class Day01
{
    public Day01()
    {
        var lines = File.ReadAllLines("Day01.txt");
        List<int> left = [];
        List<int> right = [];
        foreach (var line in lines)
        {
            var split = line.Split("   ");
            left.Add(Convert.ToInt32(split[0]));
            right.Add(Convert.ToInt32(split[1]));
        }

        left.Sort();
        right.Sort();

        // Part1(left, right);
        Part2(left, right);
    }

    private void Part1(List<int> left, List<int> right)
    {
        var sum = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine(sum);
    }

    private void Part2(List<int> left, List<int> right)
    {
        var similarity = 0;
        var j = 0;
        for (var i = 0; i < left.Count; i++)
        {
            if (left[i] > right[j])
            {
                var temp = right.IndexOf(left[i], j);
                if (temp == -1) continue;
                j = temp;
            }
            else if (left[i] < right[j])
            {
                var temp = left.IndexOf(right[j], i);
                if (temp == -1) continue;
                i = temp;
            }

            var appearance = 0;
            for (; j < right.Count && left[i] == right[j]; j++)
            {
                appearance++;
            }

            var multiplier = 0;
            j--;
            for (; i < left.Count && left[i] == right[j]; i++)
            {
                multiplier++;
            }
            j++;

            i--;
            similarity += appearance * multiplier * left[i];
            // i++;
        }

        Console.WriteLine(similarity);
    }
}