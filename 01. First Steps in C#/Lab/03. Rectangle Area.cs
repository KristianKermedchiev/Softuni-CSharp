using System;

namespace Rectable_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("ha = ");
            int b = int.Parse(Console.ReadLine());

            int area = a * b;
            Console.WriteLine($"area is = {area}");
        }
    }
}
