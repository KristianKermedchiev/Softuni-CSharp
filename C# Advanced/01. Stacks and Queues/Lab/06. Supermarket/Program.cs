﻿Queue<string> customers = new Queue<string>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "End")
    {
        Console.WriteLine($"{customers.Count} people remaining.");
        break;
    }

    if (command == "Paid")
    {
        while (customers.Count != 0)
        {
            Console.WriteLine(customers.Dequeue());
        }
    }
    else
    {
        customers.Enqueue(command);
    }
}