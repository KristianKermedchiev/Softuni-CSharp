int dimensions = int.Parse(Console.ReadLine());

char[,] field = new char[dimensions, dimensions];

int shipRow = 0;
int shipCol = 0;

int totalFishCaught = 0;

for (int row = 0; row < field.GetLength(0); row++)
{
    string newRow = Console.ReadLine();

    for (int col = 0; col < field.GetLength(1); col++)
    {
        field[row, col] = newRow[col];

        if (field[row, col] == 'S')
        {
            shipRow = row;
            shipCol = col;
        }
    }
}

string command;

while ((command = Console.ReadLine()) != "collect the nets")
{
    if (command == "left")
    {
        if (shipCol == 0)
        {
            field[shipRow, shipCol] = '-';
            shipCol = dimensions - 1;
        }
        else
        {
            field[shipRow, shipCol] = '-';
            shipCol--;
        }

        if (field[shipRow, shipCol] == 'W')
        {
            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
            Environment.Exit(0);
        }

        if (field[shipRow, shipCol] >= '0' && field[shipRow, shipCol] <= '9')
        {
            int currentCatch = field[shipRow, shipCol] - '0';
            totalFishCaught += currentCatch;
        }

        field[shipRow, shipCol] = 'S';

    }
    else if (command == "right")
    {
        if (shipCol == dimensions - 1)
        {
            field[shipRow, shipCol] = '-';
            shipCol = 0;
        }
        else
        {
            field[shipRow, shipCol] = '-';
            shipCol++;
        }

        if (field[shipRow, shipCol] == 'W')
        {
            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
            Environment.Exit(0);
        }

        if (field[shipRow, shipCol] >= '0' && field[shipRow, shipCol] <= '9')
        {
            int currentCatch = field[shipRow, shipCol] - '0';
            totalFishCaught += currentCatch;
        }

        field[shipRow, shipCol] = 'S';
    }
    else if (command == "up")
    {
        if (shipRow == 0)
        {
            field[shipRow, shipCol] = '-';
            shipRow = dimensions - 1;
        }
        else
        {
            field[shipRow, shipCol] = '-';
            shipRow--;
        }

        if (field[shipRow, shipCol] == 'W')
        {
            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
            Environment.Exit(0);
        }

        if (field[shipRow, shipCol] >= '0' && field[shipRow, shipCol] <= '9')
        {
            int currentCatch = field[shipRow, shipCol] - '0';
            totalFishCaught += currentCatch;
        }

        field[shipRow, shipCol] = 'S';
    }
    else if (command == "down")
    {
        if (shipRow == dimensions - 1)
        {
            field[shipRow, shipCol] = '-';
            shipRow = 0;
        }
        else
        {
            field[shipRow, shipCol] = '-';
            shipRow++;
        }

        if (field[shipRow, shipCol] == 'W')
        {
            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
            Environment.Exit(0);
        }

        if (field[shipRow, shipCol] >= '0' && field[shipRow, shipCol] <= '9')
        {
            int currentCatch = field[shipRow, shipCol] - '0';
            totalFishCaught += currentCatch;
        }

        field[shipRow, shipCol] = 'S';
    }
}


if (totalFishCaught < 20 && totalFishCaught > 0)
{
    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - totalFishCaught} tons of fish more.");
    Console.WriteLine($"Amount of fish caught: {totalFishCaught} tons.");

    for (int row = 0; row < dimensions; row++)
    {
        for (int col = 0; col < dimensions; col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}
else if (totalFishCaught >= 20)
{
    Console.WriteLine("Success! You managed to reach the quota!");
    Console.WriteLine($"Amount of fish caught: {totalFishCaught} tons.");

    for (int row = 0; row < dimensions; row++)
    {
        for (int col = 0; col < dimensions; col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}
else if (totalFishCaught == 0)
{
    Console.WriteLine("You didn't catch enough fish and didn't reach the quota! You need 20 tons of fish more."
);
    for (int row = 0; row < dimensions; row++)
    {
        for (int col = 0; col < dimensions; col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}
