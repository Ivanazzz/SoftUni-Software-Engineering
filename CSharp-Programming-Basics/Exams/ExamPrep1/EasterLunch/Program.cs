using System;

namespace EasterLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sweetBreadQuantity = int.Parse(Console.ReadLine());
            int crustsWithEggsQuantity = int.Parse(Console.ReadLine());
            int cookiesKgAmount = int.Parse(Console.ReadLine());

            double sweetBreadsPrice = sweetBreadQuantity * 3.20;
            double crustsWithEggsPrice = crustsWithEggsQuantity * 4.35;
            double cookiesPrice = cookiesKgAmount * 5.40;
            double eggsPaintPrice = crustsWithEggsQuantity * 12 * 0.15;
            double totalPrice = sweetBreadsPrice + crustsWithEggsPrice + cookiesPrice + eggsPaintPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
