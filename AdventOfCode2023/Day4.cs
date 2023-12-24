namespace AdventOfCode2023;

public class Day4 : Challenge
{
    public override int Part1(string input)
    {
        var lines = input.Split('\n');
        var sum = 0;

        foreach (var line in lines)
        {
            var data = line.Split(':')[1];
            var split = data.Split('|');
            var winnings = split[0].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse);
            var draws = split[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse);
            var matchCount = draws.Intersect(winnings).Count();

            if (matchCount > 0)
                sum += (int)Math.Pow(2, matchCount - 1);
        }
        
        return sum;
    }

    public override int Part2(string input)
    {
        return 0;
    }
}