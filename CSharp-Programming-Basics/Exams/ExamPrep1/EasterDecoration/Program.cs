using System;

namespace EasterDecoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfClients = int.Parse(Console.ReadLine());

            double averagePrice = 0;

            for (int client = 1; client <= numberOfClients; client++)
            {
                double price = 0;
                int purchasedItemsCount = 0;
                string product = Console.ReadLine();

                while (product != "Finish")
                {
                    switch (product)
                    {
                        case "basket":
                            price += 1.50;
                            purchasedItemsCount++;
                            break;
                        case "wreath":
                            price += 3.80;
                            purchasedItemsCount++;
                            break;
                        case "chocolate bunny":
                            price += 7;
                            purchasedItemsCount++;
                            break;
                    }
                    product = Console.ReadLine();
                }

                if (purchasedItemsCount % 2 == 0)
                {
                    price -= price * 0.2;
                }

                averagePrice += price;

                Console.WriteLine($"You purchased {purchasedItemsCount} items for {price:F2} leva.");
            }

            Console.WriteLine($"Average bill per client is: {(averagePrice / numberOfClients):F2} leva.");
        }
    }
}
