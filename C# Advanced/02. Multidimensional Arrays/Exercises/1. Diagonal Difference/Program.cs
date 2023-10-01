int sizeOfMatrix = int.Parse(Console.ReadLine());

int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

for (int row = 0; row < sizeOfMatrix; row++)
{
    int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int col = 0; col < sizeOfMatrix; col++)
    {
        matrix[row, col] = numbers[col];
    }
}

int sumLeft = 0;
int sumRight = 0;


for (int row = 0; row < sizeOfMatrix; row++)
{
    for (int col = 0; col < sizeOfMatrix; col++)
    {
        int element = matrix[row, col];

        if (row == col)
        {
            sumLeft += element;
        }

        if (col == sizeOfMatrix - 1 - row)
        {
            sumRight += element;
        }
    }
}

Console.WriteLine(Math.Abs(sumLeft-sumRight));