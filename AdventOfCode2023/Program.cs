using System.Diagnostics;
using AdventOfCode2023;

var challenges = typeof(Challenge).Assembly.GetTypes()
    .Where(x => x.BaseType == typeof(Challenge))
    .ToDictionary(x => x.Name);

Console.WriteLine("Select a challenge to run:");
foreach (var challengeKvp in challenges)
{
    var number = challengeKvp.Key.Replace("Day", "");
    Console.WriteLine($"{number}: {challengeKvp.Key}");
}

int challengeNumber;
do
{
    var userInput = Console.ReadLine();
    if (int.TryParse(userInput, out challengeNumber))
        break;
} while (true);

var challengeName = $"Day{challengeNumber}";
if (!challenges.ContainsKey(challengeName))
    return;

var challenge = challenges[challengeName];
var instance = Activator.CreateInstance(challenge) as Challenge;
var input = File.ReadAllText($"{challengeName}.txt");

var sw = new Stopwatch();
sw.Start();
var part1Result = instance!.Part1(input);
sw.Stop();

Console.WriteLine($"Part 1\n\tResult: {part1Result}\n\tTook: {sw.ElapsedMilliseconds}ms");
sw.Restart();
var part2Result = instance!.Part2(input);
sw.Stop();

Console.WriteLine($"Part 2\n\tResult: {part2Result}\n\tTook: {sw.ElapsedMilliseconds}ms");