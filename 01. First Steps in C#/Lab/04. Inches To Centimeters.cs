using System;

namespace InchesToSantimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());

            double multiplier = 2.54;
            double result = inch * multiplier;

            Console.WriteLine(result);
        }
    }
}
