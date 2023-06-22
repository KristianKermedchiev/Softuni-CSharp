using System;

namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickeMenu = 10.35;
            double fishMenu = 12.40;
            double veggieMenu = 8.15;
            double delivery = 2.50;

            int chichenCount = int.Parse(Console.ReadLine());
            int fishCount = int.Parse(Console.ReadLine());
            int veggieCount = int.Parse(Console.ReadLine());

            double total = chichenCount * chickeMenu + veggieCount * veggieMenu + fishCount * fishMenu;
            double desert = total * 0.20;
            double result = total + desert + delivery;

            Console.WriteLine(Math.Round(result, 2));
        }
    }
}
