using System;

namespace SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pen = 5.80;
            double markers = 7.20;
            double liquid = 1.2; // per litre

            int penCount = int.Parse(Console.ReadLine());
            int markerCount = int.Parse(Console.ReadLine());
            int liquidCount = int.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());

            double total = (pen * penCount) + (markers * markerCount) + (liquid * liquidCount);
            double result =  total - ( total * percentDiscount / 100 );

            Console.WriteLine(result);
        }
    }
}
