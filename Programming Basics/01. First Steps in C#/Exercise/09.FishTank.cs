
using System;

namespace FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = length * width * height;
            double liters = volume / 1000;
            double spaceReq = 1 - (percent / 100);

            Console.WriteLine(liters * spaceReq);

        }
    }
}
