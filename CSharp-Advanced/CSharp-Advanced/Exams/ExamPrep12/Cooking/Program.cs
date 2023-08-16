using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>()
            {
                { 25, new Product("Bread", 25, 0) },
                { 50, new Product("Cake", 50, 0) },
                { 100, new Product("Fruit Pie", 100, 0) },
                { 75, new Product("Pastry", 75, 0) },
            };

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Peek() + ingredients.Peek();

                if (products.ContainsKey(sum))
                {
                    products[sum].Count++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int temp = ingredients.Pop() + 3;
                    ingredients.Push(temp);
                }
            }

            bool isValid = true;
            foreach (Product product in products.Values)
            {
                if (product.Count == 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (Product product in products.Values)
            {
                Console.WriteLine($"{product.Name}: {product.Count}");
            }
        }
    }

    public class Product
    {
        public Product(string name, int value, int count)
        {
            Name = name;
            Value = value;
            Count = count;
        }

        public string Name { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}
