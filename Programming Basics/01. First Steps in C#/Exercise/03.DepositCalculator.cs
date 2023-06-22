using System;

namespace DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());  
            int time = int.Parse(Console.ReadLine());  
            double yearlyPercent = double.Parse(Console.ReadLine());
            double interest = deposit * yearlyPercent / 100;
            double monthlyInterest = interest / 12;
            double sum = deposit + time * monthlyInterest;
            Console.WriteLine(sum);
        }
    }
}
