using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            switch (figure)
            {
                case "square":
                    double SquSide = double.Parse(Console.ReadLine());
                    Console.WriteLine((SquSide * SquSide).ToString("F3"));
                    break;
                case "rectangle":
                    double RecSideA = double.Parse(Console.ReadLine());
                    double RecSideB = double.Parse(Console.ReadLine());
                    Console.WriteLine((RecSideA * RecSideB).ToString("F3"));
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine((Math.PI * Math.Pow(radius, 2)).ToString("F3"));
                    break;
                case "triangle":
                    double sideA = double.Parse(Console.ReadLine());
                    double sideB = double.Parse(Console.ReadLine());
                    Console.WriteLine(((sideA * sideB) / 2).ToString("F3"));
                    break;
            }
        }
    }
}
