using System.Text;

Queue<int> programmerTime = new (Console.ReadLine().Split(" ").Select(int.Parse));
Stack<int> numberOfTasks = new (Console.ReadLine().Split(" ").Select(int.Parse));
Dictionary<string, int> rubberDucks = new Dictionary<string, int> 
{
    { "Darth Vader Ducky", 0 },
    { "Thor Ducky", 0},
    { "Big Blue Rubber Ducky", 0 },
    { "Small Yellow Rubber Ducky", 0}
};

while (programmerTime.Count > 0 && numberOfTasks.Count > 0)
{

    int currentTime = programmerTime.Dequeue();
    int currentTask = numberOfTasks.Pop();

    int currentSum = currentTime * currentTask;

    if (currentSum >= 0 && currentSum <= 60)
    {
        rubberDucks["Darth Vader Ducky"]++;
    }
    else if (currentSum >= 61 && currentSum <= 120)
    {
        rubberDucks["Thor Ducky"]++;
    }
    else if (currentSum >= 121 && currentSum <= 180)
    {
        rubberDucks["Big Blue Rubber Ducky"]++;
    }
    else if (currentSum >= 181 && currentSum <= 240)
    {
        rubberDucks["Small Yellow Rubber Ducky"]++;
    }
    else
    {
        currentTask -= 2;
        numberOfTasks.Push(currentTask);
        programmerTime.Enqueue(currentTime);
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
foreach (var duck in rubberDucks)
{
    Console.WriteLine($"{duck.Key}: {duck.Value}");
}