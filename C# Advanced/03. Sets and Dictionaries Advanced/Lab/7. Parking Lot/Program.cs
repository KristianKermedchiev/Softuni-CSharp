HashSet<string> cars = new HashSet<string>();

string command = Console.ReadLine();

while (command != "END")
{
    string[] temp = command.Split(", ");

    string direction = temp[0];
    string carPlate = temp[1];

    if (direction == "IN")
    {
        cars.Add(carPlate);
    }
    else
    {
        cars.Remove(carPlate);
    }

    command = Console.ReadLine();
}


if (cars.Count > 0)
{
    foreach( string car in cars)
    {
        Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}
