
int sizes = int.Parse(Console.ReadLine());

int rows = (sizes);
int cols = (sizes);

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{

    int[] rowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowValues[col];
    }
}


int sum = 0;

for (int i = 0; i <matrix.GetLength(0); i++)
{
    sum += matrix[i,i];
}

Console.WriteLine(sum);