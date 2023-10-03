List<double> numbers = Console.ReadLine()
    .Split(" ")
    .Select(double.Parse)
    .ToList();

Dictionary<double, int> numbersCount = new Dictionary<double, int>();

foreach (double number in numbers)
{
    if (!numbersCount.ContainsKey(number))
    {
        numbersCount.Add(number, 1);
    }
    else
    {
        numbersCount[number]++;
    }
}

foreach (var entry in numbersCount)
{
    Console.WriteLine($"{entry.Key} - {entry.Value} times");
}