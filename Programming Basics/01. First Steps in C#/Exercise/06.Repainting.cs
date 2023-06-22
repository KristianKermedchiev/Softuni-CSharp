using System;

namespace Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nylon = 1.5;
            double paint = 14.5;
            double paintThinner = 5;
            double bags = 0.4;

            double reqNylon = double.Parse(Console.ReadLine());
            double reqPaint = double.Parse(Console.ReadLine());
            double reqPaintThinner = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double resNylon = (reqNylon + 2) * nylon;
            double resPaint = (reqPaint * 1.10) * paint;
            double resPaintThinner = (reqPaintThinner * paintThinner);

            double result = resNylon + resPaint + resPaintThinner + bags;
            double workerPay = (result * 30 / 100) * time;
            double total = result + workerPay;

            Console.WriteLine(Math.Round(total, 2));
        }
    }
}
