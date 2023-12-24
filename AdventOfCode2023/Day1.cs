namespace AdventOfCode2023;

public class Day1 : Challenge
{
    public override int Part1(string input)
    {
        var lines = input.Split('\n');
        var sum = 0;
        foreach (var line in lines)
        {
            var firstDigit = -1;
            var lastDigit = -1;
    
            foreach (var character in line)
            {
                if (Char.IsDigit(character))
                {
                    var digit = int.Parse(character.ToString());
                    if (firstDigit == -1)
                        firstDigit = digit;
                    lastDigit = digit;
                }
            }
            sum += firstDigit * 10 + lastDigit;
        }

        return sum;
    }

    public override int Part2(string input)
    {
        var lines = input.Split('\n');
        var map = new Dictionary<string, int>()
        {
            { "one",   1 },
            { "two",   2 },
            { "three", 3 },
            { "four",  4 },
            { "five",  5 },
            { "six",   6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine",  9 },
        };
        
        var sum = 0;
        foreach (var line in lines)
        {
            var firstDigit = -1;
            var lastDigit = -1;

            for (var i = 0; i < line.Length; i++)
            {
                int digit = -1;
                var character = line[i];
                if (Char.IsDigit(character))
                {
                    digit = int.Parse(character.ToString());
                }
                else
                {
                    foreach (var spelledDigit in map)
                    {
                        var digitLength = spelledDigit.Key.Length;
                        if (i + digitLength > line.Length) 
                            continue;

                        var matches = true;
                        for (int j = 0; j < digitLength; j++)
                        {
                            if (spelledDigit.Key[j] != line[i + j])
                            {
                                matches = false;
                                break;
                            }
                        }

                        if (matches)
                        {
                            digit = spelledDigit.Value;
                        }
                    }
                }

                if (digit != -1)
                {
                    if (firstDigit == -1)
                        firstDigit = digit;
                    lastDigit = digit;
                }
            }

            sum += firstDigit * 10 + lastDigit;
        }
        return sum;
    }
}