namespace AdventOfCode2024;

public class Day08
{
    public Day08()
    {
        var map = File.ReadAllLines("Day08.txt").Select(y => y.Select(x => x).ToArray()).ToArray();
        Part2(map);
    }

    private void Part1(char[][] map)
    {
        List<(char, List<(int x, int y)>)> antennass = [];
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                if (map[y][x] != '.')
                {
                    var an = antennass.FirstOrDefault(an => an.Item1.Equals(map[y][x]));
                    if (an.Item2 == null)
                    {
                        an = (map[y][x], new List<(int x, int y)>());
                        antennass.Add(an);
                    }

                    an.Item2.Add((x, y));
                }
            }
        }

        HashSet<(int x, int y)> antinodes = [];
        foreach (var antennas in antennass)
        {
            for (int i = 0; i < antennas.Item2.Count; i++)
            {
                for (int j = 0; j < antennas.Item2.Count; j++)
                {
                    if (i == j) continue;

                    var a = antennas.Item2[i];
                    var b = antennas.Item2[j];
                    var v = a.y - b.y;
                    var h = a.x - b.x;

                    var newX = a.x + h;
                    var newY = a.y + v;

                    if (newX >= map[0].Length || newX < 0 || newY >= map.Length || newY < 0) continue;

                    antinodes.Add((newX, newY));
                }
            }
        }

        Console.WriteLine(antinodes.Count);

        foreach (var antinode in antinodes)
        {
            map[antinode.y][antinode.x] = '#';
        }

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                Console.Write(map[y][x]);
            }

            Console.WriteLine();
        }
    }

    private void Part2(char[][] map)
    {
        List<(char, List<(int x, int y)>)> antennass = [];
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                if (map[y][x] != '.')
                {
                    var an = antennass.FirstOrDefault(an => an.Item1.Equals(map[y][x]));
                    if (an.Item2 == null)
                    {
                        an = (map[y][x], new List<(int x, int y)>());
                        antennass.Add(an);
                    }

                    an.Item2.Add((x, y));
                }
            }
        }

        HashSet<(int x, int y)> antinodes = [];
        foreach (var antennas in antennass)
        {
            for (int i = 0; i < antennas.Item2.Count; i++)
            {
                for (int j = 0; j < antennas.Item2.Count; j++)
                {
                    if (i == j) continue;

                    var a = antennas.Item2[i];
                    var b = antennas.Item2[j];
                    Extrapolate(a, b);
                }
            }
        }

        foreach (var antinode in antinodes)
        {
            map[antinode.y][antinode.x] = '#';
        }

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                Console.Write(map[y][x]);
            }

            Console.WriteLine();
        }

        var allAntennas = antennass.SelectMany(an => an.Item2).ToList();
        foreach (var antennas in allAntennas)
        {
            antinodes.Add(antennas);
        }

        Console.WriteLine(antinodes.Count);

        void Extrapolate((int x, int y) a, (int x, int y) b)
        {
            var h = a.x - b.x;
            var v = a.y - b.y;

            var newX = a.x + h;
            var newY = a.y + v;

            if (newX >= map[0].Length || newX < 0 || newY >= map.Length || newY < 0) return;
            antinodes.Add((newX, newY));
            Extrapolate((newX, newY), a);
        }
    }
}