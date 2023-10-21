using System.Text;

Stack<int> initialFuel = new(Console.ReadLine().Split(" ").Select(int.Parse));

Queue<int> additionalConsumption = new(Console.ReadLine().Split(" ").Select(int.Parse));

Queue<int> amountNeeded = new(Console.ReadLine().Split(" ").Select(int.Parse));

int altitudeCount = 0;
bool hasReachedTop = true;

while (initialFuel.Any())
{

    int currentFuel = initialFuel.Pop();
    int currentConsumption = additionalConsumption.Dequeue();
    int currentAmountNeeded = amountNeeded.Dequeue();

    if (currentFuel - currentConsumption >= currentAmountNeeded)
    {
        altitudeCount++;
        Console.WriteLine($"John has reached: Altitude {altitudeCount}");
        continue;
    }
    else
    {
        altitudeCount++;
        Console.WriteLine($"John did not reach: Altitude {altitudeCount}");
        hasReachedTop = false;
        break;
    }
}

if (altitudeCount == 1 && hasReachedTop == false)
{
    Console.WriteLine("John failed to reach the top.");
    Console.WriteLine("John didn't reach any altitude.");
}
else if (altitudeCount > 1 && hasReachedTop == false)
{
    Console.WriteLine($"John failed to reach the top.");
    StringBuilder sb = new StringBuilder();
    sb.Append("Reached altitudes: ");

    for (int i = 1; i < altitudeCount; i++)
    {
        if (i + 1 == altitudeCount)
        {
            sb.Append($"Altitude {i}");
        }
        else
        {
            sb.Append($"Altitude {i}, ");
        }
    }
    Console.WriteLine(sb);
}
else if (hasReachedTop == true)
{
    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
}