int greenLightSeconds = int.Parse(Console.ReadLine());

int freeWindowSeconds = int.Parse(Console.ReadLine());

string command = Console.ReadLine();

Queue<string> cars = new Queue<string>();

int passedCars = 0;

while (command != "END")
{
    if (command != "green")
    {
        cars.Enqueue(command); 
        command = Console.ReadLine();
        continue;
    }

    int currentGreenLightSeconds = greenLightSeconds;

    while (cars.Count > 0 && currentGreenLightSeconds > 0)
    {
        string currentCar = cars.Dequeue();
        if (currentGreenLightSeconds - currentCar.Length > 0)
        {
            currentGreenLightSeconds -= currentCar.Length;
            passedCars++;
            continue;
        }
        else if (currentGreenLightSeconds + freeWindowSeconds - currentCar.Length >= 0)
        {
            passedCars++;
            break;
        }
        else
        {
            char hitSymbol = currentCar[currentGreenLightSeconds + freeWindowSeconds];
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{currentCar} was hit at {hitSymbol}.");

            return;
        }

    }
    command = Console.ReadLine();
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{passedCars} total cars passed the crossroads.");