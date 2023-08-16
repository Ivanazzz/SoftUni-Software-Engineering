using System;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string, Product> priceAndQuantityByProduct = new Dictionary<string, Product>();

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "buy")
                {
                    break;
                }

                string name = command[0];
                double price = double.Parse(command[1]);
                int quantity = int.Parse(command[2]);   

                if (priceAndQuantityByProduct.ContainsKey(name))
                {
                    priceAndQuantityByProduct[name].Price = price;
                    priceAndQuantityByProduct[name].Quantity += quantity;
                }
                else
                {
                    priceAndQuantityByProduct.Add(name, new Product(name, price, quantity));
                }
            }

            foreach (var product in priceAndQuantityByProduct)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value.Quantity * product.Value.Price):f2}");
            }
        }
    }

    internal class Product
    {
        public Product(string product, double price, int quantity)
        {
            this.Name = product;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
