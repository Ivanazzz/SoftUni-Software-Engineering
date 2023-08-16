using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> quantitiesByCoffee = new Dictionary<int, string>()
            {
                { 50, "Cortado" },
                { 75, "Espresso" },
                { 100, "Capuccino" },
                { 150, "Americano" },
                { 200, "Latte" },
            };
            Dictionary<string, int> coffeeTypeQuantity = new Dictionary<string, int>();

            Queue<int> coffeeQuantity = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> milkQuantity = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (coffeeQuantity.Any() && milkQuantity.Any())
            {
                int currentCoffeeQuantity = coffeeQuantity.Peek() + milkQuantity.Peek();
                if (quantitiesByCoffee.ContainsKey(currentCoffeeQuantity))
                {
                    string currentCoffeeType = quantitiesByCoffee[currentCoffeeQuantity];
                    if (!coffeeTypeQuantity.ContainsKey(currentCoffeeType))
                    {
                        coffeeTypeQuantity.Add(currentCoffeeType, 0);
                    }
                    coffeeTypeQuantity[currentCoffeeType]++;

                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else
                {
                    coffeeQuantity.Dequeue();
                    int tempMilkQuantity = milkQuantity.Pop();
                    tempMilkQuantity -= 5;
                    milkQuantity.Push(tempMilkQuantity);
                }
            }

            PrintMilkAndCoffeeQuantity(coffeeQuantity, milkQuantity);

            coffeeTypeQuantity = coffeeTypeQuantity
                .OrderBy(c => c.Value)
                .ThenByDescending(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var coffee in coffeeTypeQuantity)
            {
                Console.WriteLine($"{coffee.Key}: {coffee.Value}");
            }


        }

        private static void PrintMilkAndCoffeeQuantity(Queue<int> coffeeQuantity, Stack<int> milkQuantity)
        {
            if (!coffeeQuantity.Any() && !milkQuantity.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuantity.Any())
            {
                Console.Write("Coffee left: ");
                Console.WriteLine(string.Join(", ", coffeeQuantity));
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkQuantity.Any())
            {
                Console.Write("Milk left: ");
                Console.WriteLine(string.Join(", ", milkQuantity));
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }
        }
    }
}
