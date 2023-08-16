using System;

namespace EasterBakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double flourPricePerKg = double.Parse(Console.ReadLine());
            double flourKg = double.Parse(Console.ReadLine());
            double sugarKg = double.Parse(Console.ReadLine());
            int crustsWithEggsQuantity = int.Parse(Console.ReadLine());
            int yeastPackagesQuantity = int.Parse(Console.ReadLine());

            double sugarPricePerKg = flourPricePerKg - (flourPricePerKg * 0.25);
            double eggsPricePerCrust = flourPricePerKg + (flourPricePerKg * 0.1);
            double yeastPricePackage = sugarPricePerKg - (sugarPricePerKg * 0.8);

            double floursPrice = flourKg * flourPricePerKg;
            double sugarPrice = sugarKg * sugarPricePerKg;
            double crustsWithEggsPrice = crustsWithEggsQuantity * eggsPricePerCrust;
            double yeastPackagesPrice = yeastPackagesQuantity * yeastPricePackage;
            double totalPrice = floursPrice + sugarPrice + crustsWithEggsPrice + yeastPackagesPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
