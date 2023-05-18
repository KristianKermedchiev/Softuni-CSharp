using System;

namespace YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMeters = double.Parse(Console.ReadLine());
                
            double sqMeter = 7.61;

            double discount = (0.18 * (neededMeters * sqMeter));

            double result = ((neededMeters * sqMeter) - discount);

            Console.WriteLine($"The final price is: {result} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
