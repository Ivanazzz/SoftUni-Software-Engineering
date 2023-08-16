using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>()
            {
                { "Croissant", new Product("Croissant", 50, 50) },
                { "Muffin", new Product("Muffin", 40, 60) },
                { "Baguette", new Product("Baguette", 30, 70) },
                { "Bagel", new Product("Bagel", 20, 80) },
            };

            Dictionary<string, int> countByMadeProduct = new Dictionary<string, int>();

            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            while (water.Any() && flour.Any())
            {
                bool isProductMade = false;
                double waterFlourSum = water.Peek() + flour.Peek();

                foreach (Product product in products.Values)
                {
                    if (((water.Peek() * 100) / waterFlourSum) == product.Water)
                    {
                        if (!countByMadeProduct.ContainsKey(product.Type))
                        {
                            countByMadeProduct.Add(product.Type, 0);
                        }

                        countByMadeProduct[product.Type]++;
                        isProductMade = true;
                        water.Dequeue();
                        flour.Pop();
                        break;
                    }
                }

                if (!isProductMade)
                {
                    if (!countByMadeProduct.ContainsKey("Croissant"))
                    {
                        countByMadeProduct.Add("Croissant", 0);
                    }

                    countByMadeProduct["Croissant"]++;
                    double flourNew = flour.Pop() - water.Dequeue();
                    flour.Push(flourNew);
                }
            }

            countByMadeProduct = countByMadeProduct.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var product in countByMadeProduct)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }

    internal class Product
    {
        public Product(string type, int water, int flour)
        {
            this.Type = type;
            this.Water = water;
            this.Flour = flour;
        }

        public string Type { get; set; }
        public int Water { get; set; }
        public int Flour { get; set; }
    }
}
