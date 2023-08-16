using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProductPrice = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProductPrice.ContainsKey(shop))
                {
                    shopProductPrice.Add(shop, new Dictionary<string, double>());
                }
                shopProductPrice[shop].Add(product, price);

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries); 
            }

            shopProductPrice = shopProductPrice.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in shopProductPrice)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
