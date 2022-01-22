using System;

namespace VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPricePerKg = double.Parse(Console.ReadLine());
            double fruitsPricePerKg = double.Parse(Console.ReadLine());
            int vegetablesKg = int.Parse(Console.ReadLine());
            int fruitsKg = int.Parse(Console.ReadLine());

            double totalPriceInLv = (vegetablesPricePerKg * vegetablesKg) + (fruitsPricePerKg * fruitsKg);
            double totalPriceInEu = totalPriceInLv / 1.94;

            Console.WriteLine($"{totalPriceInEu:F2}");
        }
    }
}
