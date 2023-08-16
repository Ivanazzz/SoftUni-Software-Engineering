using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            int count = 1;
            foreach (string product in products)
            {
                Console.WriteLine($"{count}.{product}");
                count++;
            }
        }
    }
}
