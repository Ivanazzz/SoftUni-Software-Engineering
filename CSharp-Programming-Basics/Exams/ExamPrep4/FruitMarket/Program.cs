using System;

namespace FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPricePerKg = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberriesKg = double.Parse(Console.ReadLine());
            double strawberriesKg = double.Parse(Console.ReadLine());

            double raspberriesPricePerKg = strawberriesPricePerKg / 2;
            double orangesPricePerKg = raspberriesPricePerKg - (raspberriesPricePerKg * 0.4);
            double bananasPricePerKg = raspberriesPricePerKg - (raspberriesPricePerKg * 0.8);

            double strawberriesTotalPrice = strawberriesKg * strawberriesPricePerKg;
            double raspberriesTotalPrice = raspberriesKg * raspberriesPricePerKg;
            double orangesTotalPrice = orangesKg * orangesPricePerKg;
            double bananasTotalPrice = bananasKg * bananasPricePerKg;
            double totalPrice = strawberriesTotalPrice + raspberriesTotalPrice + orangesTotalPrice + bananasTotalPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
