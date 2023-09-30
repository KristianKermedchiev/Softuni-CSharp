int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> racks = new Stack<int>(input);

int capacity = int.Parse(Console.ReadLine());

int totalUsedRacks = 1;
int currentCapacity = 0;

while (racks.Count > 0)
{
    int currentValue = racks.Pop();

    if (currentValue + currentCapacity <= capacity)
    {
        currentCapacity += currentValue;
    }
    else
    {
        totalUsedRacks ++;
        currentCapacity = currentValue;
    }
}

Console.WriteLine(totalUsedRacks);