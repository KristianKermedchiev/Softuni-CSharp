int[] dimensions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] field = new char[dimensions[0], dimensions[1]];

int boyRow = 0;
int boyCol = 0;

int boyInitialRow = 0;
int boyInitialCol = 0;

for (int row = 0; row < field.GetLength(0); row++)
{
    string newRow = Console.ReadLine();

    for (int col = 0; col < field.GetLength(1); col++)
    {
        field[row, col] = newRow[col];

        if (field[row, col] == 'B')
        {
            boyRow = row;
            boyCol = col;

            boyInitialRow = row;
            boyInitialCol = col;
        }
    }
}

bool isOutsideFiled = false;

while (true)
{
    string command = Console.ReadLine();

    if (command == "left")
    {
        if(boyCol == 0)
        {
            if (field[boyRow, boyCol] == '-')
            {
                field[boyRow, boyCol] = '.';
            }

            isOutsideFiled = true;

            Console.WriteLine("The delivery is late. Order is canceled.");

            break;
        }

        if (field[boyRow, boyCol - 1] == '*')
        {
            continue;
        }

        if (field[boyRow, boyCol] != 'R')
        {
            field[boyRow, boyCol] = '.';
        }

        boyCol--;
    }
    else if (command == "right")
    {
        if (boyCol == field.GetLength(1) - 1)
        {
            if (field[boyRow, boyCol] == '-')
            {
                field[boyRow, boyCol] = '.';
            }

            isOutsideFiled = true;

            Console.WriteLine("The delivery is late. Order is canceled.");

            break;
        }

        if (field[boyRow, boyCol + 1] == '*')
        {
            continue;
        }

        if (field[boyRow, boyCol] != 'R')
        {
            field[boyRow, boyCol] = '.';
        }

        boyCol++;
    }
    else if (command == "up")
    {
        if (boyRow == 0)
        {
            if (field[boyRow, boyCol] == '-')
            {
                field[boyRow, boyCol] = '.';
            }

            isOutsideFiled = true;

            Console.WriteLine("The delivery is late. Order is canceled.");

            break;
        }

        if (field[boyRow - 1, boyCol] == '*')
        {
            continue;
        }

        if (field[boyRow, boyCol] != 'R')
        {
            field[boyRow, boyCol] = '.';
        }

        boyRow--;
    }
    else if (command == "down")
    {
        if (boyRow == field.GetLength(0) - 1)
        {
            if (field[boyRow, boyCol] == '-')
            {
                field[boyRow, boyCol] = '.';
            }

            isOutsideFiled = true;

            Console.WriteLine("The delivery is late. Order is canceled.");

            break;
        }

        if (field[boyRow + 1, boyCol] == '*')
        {
            continue;
        }

        if (field[boyRow, boyCol] != 'R')
        {
            field[boyRow, boyCol] = '.';
        }

        boyRow++;
    }

    if (field[boyRow, boyCol] == 'P')
    {
        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
        field[boyRow, boyCol] = 'R';

        continue;
    }

    if (field[boyRow, boyCol] == 'A')
    {
        Console.WriteLine("Pizza is delivered on time! Next order...");

        field[boyRow, boyCol] = 'P';

        break;
    }
}

if (isOutsideFiled)
{
    field[boyInitialRow, boyInitialCol] = ' ';
}
else
{
    field[boyInitialRow, boyInitialCol] = 'B';

}


for (int row = 0; row < field.GetLength(0); row++)
{
    for (int col = 0; col < field.GetLength(1); col++)
    {
        Console.Write(field[row, col]);
    }

    Console.WriteLine();
}