using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());

            double shoes = tax * 0.6;
            double shirt = shoes * 0.8;
            double ball = shirt * 0.25;
            double accessories = ball * 0.20;

            Console.WriteLine(tax + shoes + shirt + accessories + ball);

        }
    }
}
