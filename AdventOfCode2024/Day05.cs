namespace AdventOfCode2024;

public class Day05
{
    public Day05()
    {
        var lines = File.ReadAllLines("Day05.txt");
        List<(int, int)> rules = [];
        List<List<int>> updates = [];

        // rules
        int i = 0;
        for (; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
            {
                i++;
                break;
            }

            var split = lines[i].Split('|');
            rules.Add((int.Parse(split[0]), int.Parse(split[1])));
        }

        // updates
        for (; i < lines.Length; i++)
        {
            var split = lines[i].Split(',');
            List<int> update = [];

            foreach (var s in split)
            {
                update.Add(int.Parse(s));
            }

            updates.Add(update);
        }

        // Part1(rules, updates);
        Part2(rules, updates);
    }

    private void Part1(List<(int, int)> rules, List<List<int>> updates)
    {
        var sum = 0;
        foreach (var update in updates)
        {
            try
            {
                foreach (var rule in rules)
                {
                    Adheres(update, rule);
                }

                sum += update[update.Count / 2];
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        Console.WriteLine(sum);
    }

    private void Adheres(List<int> update, (int, int) rule)
    {
        if (!(update.Contains(rule.Item1) && update.Contains(rule.Item2))) return;

        if (update.IndexOf(rule.Item1) > update.IndexOf(rule.Item2))
        {
            throw new Exception("Does not adhere");
        }
    }

    private void Part2(List<(int, int)> rules, List<List<int>> updates)
    {
        var sum = 0;
        var incorrectUpdates = new List<List<int>>();
        foreach (var update in updates)
        {
            try
            {
                foreach (var rule in rules)
                {
                    Adheres(update, rule);
                }
            }
            catch (Exception e)
            {
                incorrectUpdates.Add(update);
            }
        }

        for (int i = 0; i < incorrectUpdates.Count; i++)
        {
            // for good measure LOL!
            for (int j = 0; j < 10; j++)
            {
                foreach (var rule in rules)
                {
                    incorrectUpdates[i] = Correct(incorrectUpdates[i], rule);
                }
            }
            // Console.WriteLine(string.Join(",", incorrectUpdates[i]));
            sum += incorrectUpdates[i][incorrectUpdates[i].Count / 2];
        }

        Console.WriteLine(sum);
    }

    private List<int> Correct(List<int> update, (int, int) rule)
    {
        if (!(update.Contains(rule.Item1) && update.Contains(rule.Item2))) return update;

        var indexOfA = update.IndexOf(rule.Item1);
        var indexOfB = update.IndexOf(rule.Item2);
        if (indexOfA > indexOfB)
        {
            update[indexOfA] = rule.Item2;
            update[indexOfB] = rule.Item1;
        }

        return update;
    }
}