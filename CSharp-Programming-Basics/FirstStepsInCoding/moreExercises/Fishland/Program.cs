using System;

namespace Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mackerelPricePerKg = double.Parse(Console.ReadLine());
            double spratPricePerKg = double.Parse(Console.ReadLine());
            double bonitoKg = double.Parse(Console.ReadLine());
            double scadKg = double.Parse(Console.ReadLine());
            double clamKg = double.Parse(Console.ReadLine());

            double bonitoPricePerKg = mackerelPricePerKg + (mackerelPricePerKg * 0.6);
            double scadPricePerKg = spratPricePerKg + (spratPricePerKg * 0.8);
            double clamPricePerKg = 7.50;

            double bonitoTotalPrice = bonitoPricePerKg * bonitoKg;
            double scadTotalPrice = scadPricePerKg * scadKg;
            double clamTotalPrice = clamPricePerKg * clamKg;

            double totalPrice = bonitoTotalPrice + scadTotalPrice + clamTotalPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
