int[] values = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int valuesToPush = values[0];
int valuesToPop = values[1];
int lookUpValue = values[2];

Queue<int> queue = new Queue<int>(input.Take(valuesToPush));


for (int i = 0; i < valuesToPop && queue.Count > 0; i++)
{
    queue.Dequeue();
}

if (queue.Contains(lookUpValue))
{
    Console.WriteLine("true");
}
else if (queue.Count == 0)
{
    Console.WriteLine("0");
}
else
{
    Console.WriteLine(queue.Min());
}