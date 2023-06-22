using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double course = 1.79549;

            double usd = double.Parse(Console.ReadLine());
            double leva = usd * course;

            Console.WriteLine(leva);
        }
    }
}
