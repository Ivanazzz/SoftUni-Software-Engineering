using System;

namespace TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            int productsCount = 0;
            double productsTotalPrice = 0;

            string product = Console.ReadLine();

            while (product != "Stop")
            {
                double productsPrice = double.Parse(Console.ReadLine());
                productsCount++;

                if (productsPrice > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {(productsPrice - budget):F2} leva!");
                    return;
                }

                if (productsCount % 3 == 0)
                {
                    budget -= productsPrice / 2;
                    productsTotalPrice += productsPrice / 2;
                }
                else
                {
                    budget -= productsPrice;
                    productsTotalPrice += productsPrice;
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"You bought {productsCount} products for {productsTotalPrice:F2} leva.");
        }
    }
}
