namespace AdventOfCode2023;

public class Day2 : Challenge
{
    public override int Part1(string input)
    {
        var cubeCounts = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        var sum = 0;
        
        var lines = input.Split('\n');
        foreach (var line in lines)
        {
            var split=  line.Split(':');
            var gameId = int.Parse(split[0].Replace("Game ", ""));

            var sets = split[1].Split(';');
            var foundFakeDraw = false;
            
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    var split2 = cube.Trim().Split(' ');
                    var count = int.Parse(split2[0]);
                    var color = split2[1];

                    if (cubeCounts[color] < count)
                    {
                        foundFakeDraw = true;
                        break;
                    }
                }

                if (foundFakeDraw)
                    break;
            }

            if (foundFakeDraw == false)                     
                sum += gameId;
        }

        return sum;
    }

    public override int Part2(string input)
    {  
        var sum = 0;
        
        var lines = input.Split('\n');
        foreach (var line in lines)
        {
            var minimumCubeCounts = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
            
            var split=  line.Split(':');
            var sets = split[1].Split(';');
            
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var cube in cubes)
                {
                    var split2 = cube.Trim().Split(' ');
                    var count = int.Parse(split2[0]);
                    var color = split2[1];

                    if (minimumCubeCounts[color] < count)
                        minimumCubeCounts[color] = count;
                }
            }
            sum += minimumCubeCounts.Values.Aggregate(1, (acc, val) => acc * val);
        }

        return sum;
    }
}