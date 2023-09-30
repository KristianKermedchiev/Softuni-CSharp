int[] values = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int valuesToPush = values[0];
int valuesToPop  = values[1];
int lookUpValue = values[2];

Stack<int> stack = new Stack<int>();

for (int i = 0; i < valuesToPush; i++)
{
    stack.Push(input[i]);
}

for (int i = 0; i < valuesToPop && stack.Count > 0; i++)
{
    stack.Pop();
}

if (stack.Contains(lookUpValue))
{
    Console.WriteLine("true");
}
else if (stack.Count == 0)
{
    Console.WriteLine("0");
}
else
{
    Console.WriteLine(stack.Min());
}