List<int> numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

List<int> largestThreeNumbers = numbers
    .OrderByDescending(x => x)
    .Take(3)
    .ToList();

Console.WriteLine(String.Join(" ", largestThreeNumbers));
