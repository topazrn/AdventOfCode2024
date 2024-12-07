namespace AdventOfCode2024;

public class Day07
{
    public Day07()
    {
        // Console.WriteLine(GetWeirdBase3Value(3));
        //
        // Console.WriteLine(GetWeirdBase3Value(0).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(1).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(2).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(3).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(4).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(5).PadLeft(3, '0'));
        // Console.WriteLine(GetWeirdBase3Value(6).PadLeft(3, '0'));
        var lines = File.ReadAllLines("Day07.txt");
        var tests = new List<(long result, List<long> numbers)>();
        foreach (var line in lines)
        {
            var colonIndex = line.IndexOf(':');
            var result = long.Parse(line.Substring(0, colonIndex));
            var numbersString = line.Substring(colonIndex + 2);
            var numbers = numbersString.Split(' ').Select(long.Parse).ToList();
            tests.Add((result, numbers));
        }
        
        Part2(tests);
    }

    private void Part1(List<(long result, List<long> numbers)> tests)
    {
        long sum = 0;
        foreach (var test in tests)
        {
            // Console.WriteLine(test.result);
            for (var i = 0; i < Math.Pow(2, test.numbers.Count); i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(test.numbers.Count, '0');
                // Console.WriteLine(binary);
                long temp = 0;
                for (int j = 0; j < test.numbers.Count; j++)
                {
                    switch (binary[j])
                    {
                        case '0':
                            temp += test.numbers[j];
                            break;
                        case '1':
                            temp *= test.numbers[j];
                            break;
                    }
                }

                if (temp == test.result)
                {
                    sum += test.result;
                    break;
                }
            }
            // Console.WriteLine();
        }

        Console.WriteLine(sum);
    }

    private void Part2(List<(long result, List<long> numbers)> tests)
    {
        long sum = 0;
        foreach (var test in tests)
        {
            // Console.WriteLine(test.result);
            for (var i = 0; i < Math.Pow(3, test.numbers.Count - 1); i++)
            {
                string binary = GetWeirdBase3Value(i).PadLeft(test.numbers.Count - 1, '0');
                // Console.WriteLine(binary);
                long temp = test.numbers[0];
                for (int j = 0; j < binary.Length; j++)
                {
                    switch (binary[j])
                    {
                        case '0':
                            temp += test.numbers[j + 1];
                            break;
                        case '1':
                            temp *= test.numbers[j + 1];
                            break;
                        case '2':
                            temp = long.Parse($"{temp}{test.numbers[j + 1]}");
                            break;
                    }
                }

                if (temp == test.result)
                {
                    sum += test.result;
                    break;
                }
            }

            // Console.WriteLine();
        }

        Console.WriteLine(sum);
    }

    private string GetWeirdBase3Value(int input)
    {
        if (input == 0) return "0";

        string base3 = "";
        while (input > 0)
        {
            int remainder = input % 3;
            base3 = remainder.ToString() + base3; // Prepend remainder
            input /= 3; // Divide the number by 3
        }

        return base3;
    }
}