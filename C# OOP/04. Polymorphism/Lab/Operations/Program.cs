

namespace Operations
{
    public class StartUp
    {
        static void Main()
        {
            MathOperations mathOperations = new MathOperations();

            Console.WriteLine(mathOperations.Add(5, 5));
            Console.WriteLine(mathOperations.Add(5m, 5m, 6m));
            Console.WriteLine(mathOperations.Add(5d, 5d, 7d));

        }
    }
}