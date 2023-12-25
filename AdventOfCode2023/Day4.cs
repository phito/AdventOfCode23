using System.Diagnostics;

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
        var lines = input.Split('\n');
        var cache = new Dictionary<int, int>();
        var cardCount = 0;

        void ProcessCard(int cardIndex)
        {
            var matchCount = 0;
            if (cache.TryGetValue(cardIndex, out var value))
            {
                matchCount = value;
            }
            else
            {
                var line = lines![cardIndex];
                var data = line.Split(':')[1];
                var split = data.Split('|');
                var winnings = split[0].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse);
                var draws = split[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse);
                matchCount = draws.Intersect(winnings).Count();
                cache[cardIndex] = matchCount;
            }

            for (int j = 1; j <= matchCount; j++)
            {
                if (cardIndex + j > lines.Length) break;
                ProcessCard(cardIndex + j);
            }

            cardCount++;
        }
        
        for (var i = 0; i < lines.Length; i++)
            ProcessCard(i);

        return cardCount;
    }
}