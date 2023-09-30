int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> bottles = new Stack<int>(inputBottles);
Queue<int> cups = new Queue<int>(inputCups);

int wastedWater = 0;

while (cups.Count > 0 && bottles.Count > 0)
{
    int currentBottle = bottles.Pop();
    int currentCup = cups.Dequeue();

    if (currentBottle >= currentCup)
    {
        wastedWater += currentBottle - currentCup;
        continue;
    }
    else
    {
        currentCup -= currentBottle;

        while (currentCup > 0)
        {
            currentCup -= bottles.Pop();

            if (currentCup < 0)
            {
                wastedWater += currentCup * -1;
            }
        }
    }
}

if (cups.Count > 0)
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}
else
{
    Console.WriteLine($"Bottles: {string.Join(" " , bottles)}");
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");
