namespace AdventOfCode2023;

public class Day3 : Challenge
{
    public override int Part1(string input)
    {
        var matrix = input.Split('\n').Select(x => x.ToArray()).ToArray();
        var lineCount = matrix.Length;
        var columnCount = matrix[0].Length;
        var sum = 0;
        
        for (var i = 0; i < lineCount; i++)
        {
            var line = matrix[i];

            var currentNumber = 0;
            var hasSymbolNeighbor = false;
            for (var j = 0; j < columnCount; j++)
            {
                var character = line[j];
                var isCharacterDigit = Char.IsDigit(character);
                if (isCharacterDigit)
                {
                    currentNumber *= 10;
                    currentNumber += int.Parse(character.ToString());
            
                    for (var ii = i - 1; ii <= i + 1; ii++)
                    for (var jj = j - 1; jj <= j + 1; jj++)
                    {
                        if (ii < 0 || jj < 0 || ii >= lineCount || jj >= columnCount || (ii == 0 && jj == 0))
                            continue;
                        var neighbor = matrix[ii][jj];
                        if(neighbor != '.' && !Char.IsDigit(neighbor))
                            hasSymbolNeighbor = true;
                    }
                }
                if((!isCharacterDigit || j == columnCount - 1) && currentNumber != 0)
                {
                    if (hasSymbolNeighbor)
                        sum += currentNumber;

                    currentNumber = 0;
                    hasSymbolNeighbor = false;
                }
            }
        }

        return sum;
    }

    public override int Part2(string input)
    {
        var matrix = input.Split('\n').Select(x => x.ToArray()).ToArray();
        var lineCount = matrix.Length;
        var columnCount = matrix[0].Length;

        var gears = new Dictionary<(int, int), List<int>>();
        for (var i = 0; i < lineCount; i++)
        {
            var line = matrix[i];

            var currentNumber = 0;
            (int, int)? gearPosition = null;
            
            for (var j = 0; j < columnCount; j++)
            {
                var character = line[j];
                var isCharacterDigit = Char.IsDigit(character);
                if (isCharacterDigit)
                {
                    currentNumber *= 10;
                    currentNumber += int.Parse(character.ToString());
                
                    for (var ii = i - 1; ii <= i + 1; ii++)
                    for (var jj = j - 1; jj <= j + 1; jj++)
                    {
                        if (ii < 0 || jj < 0 || ii >= lineCount || jj >= columnCount || (ii == 0 && jj == 0))
                            continue;
                        if(matrix[ii][jj] == '*')
                            gearPosition = (ii, jj);
                    }
                }
                if((!isCharacterDigit || j == columnCount - 1) && currentNumber != 0)
                {
                    if (gearPosition != null)
                    {
                        if (gears.ContainsKey(gearPosition.Value))
                            gears[gearPosition.Value].Add(currentNumber);
                        else
                            gears[gearPosition.Value] = new List<int> { currentNumber };
                    }

                    currentNumber = 0;
                    gearPosition = null;
                }
            }
        }

        return gears
            .Where(x => x.Value.Count > 1)
            .Select(x => x.Value.Aggregate(1, (acc, val) => acc * val))
            .Sum();
    }
}