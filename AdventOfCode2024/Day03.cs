namespace AdventOfCode2024;

public class Day03
{
    public Day03()
    {
        var text = File.ReadAllText("Day03.txt");

        // Part1(text);
        Part2(text);
    }

    private void Part1(string text)
    {
        var sum = 0;
        var lastIndex = 0;
        while (lastIndex != -1)
        {
            lastIndex = text.IndexOf("mul(", lastIndex + 1);
            if (lastIndex == -1) continue;

            var range = text.Substring(lastIndex, Math.Min(12, text.Length - lastIndex));
            var closingIndex = range.IndexOf(")");
            if (closingIndex == -1) continue;

            var commaIndex = range.IndexOf(",");
            if (commaIndex == -1) continue;
            if (commaIndex > closingIndex) continue;

            var numbers = range.Substring(4, closingIndex - 4).Split(',');
            try
            {
                sum += int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }
            catch (FormatException fe)
            {
            }
        }

        Console.WriteLine(sum);
    }

    private void Part2(string text)
    {
        var toggles = Toggle(text);
        var sum = 0;
        var lastToggleIndex = -1;
        var lastIndex = 0;
        while (lastIndex != -1)
        {
            lastIndex = text.IndexOf("mul(", lastIndex + 1);
            if (lastIndex == -1) continue;
            
            for (int i = lastToggleIndex; i < toggles.Length; i++)
            {
                if (i == -1) continue;
                if (toggles[i] < lastIndex)
                {
                    lastToggleIndex = i;
                }
            }
            if (lastToggleIndex % 2 == 0) continue;

            var range = text.Substring(lastIndex, Math.Min(12, text.Length - lastIndex));
            var closingIndex = range.IndexOf(")");
            if (closingIndex == -1) continue;

            var commaIndex = range.IndexOf(",");
            if (commaIndex == -1) continue;
            if (commaIndex > closingIndex) continue;

            var numbers = range.Substring(4, closingIndex - 4).Split(',');
            try
            {
                sum += int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }
            catch (FormatException fe)
            {
            }
        }

        Console.WriteLine(sum);
    }

    private int[] Toggle(string text)
    {
        var toggles = new List<int>();
        var lastIndex = 0;
        while (lastIndex != -1)
        {
            lastIndex = text.IndexOf(toggles.Count % 2 == 0 ? "don't()" : "do()", lastIndex + 1);
            if (lastIndex == -1) continue;
            
            toggles.Add(lastIndex);
        }
        
        return toggles.ToArray();
    }
}