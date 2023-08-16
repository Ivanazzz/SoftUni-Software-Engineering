using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> milligramsOfCaffeinе = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int maximumCaffeine = 300;
            int consumedCaffeine = 0;

            while (milligramsOfCaffeinе.Any() && energyDrinks.Any())
            {
                int currentTotalCaffeine = milligramsOfCaffeinе.Peek() * energyDrinks.Peek();

                if (consumedCaffeine + currentTotalCaffeine <= maximumCaffeine)
                {
                    consumedCaffeine += currentTotalCaffeine;
                    milligramsOfCaffeinе.Pop();
                    energyDrinks.Dequeue();
                }
                else
                {
                    milligramsOfCaffeinе.Pop();
                    int temp = energyDrinks.Dequeue();
                    energyDrinks.Enqueue(temp);

                    consumedCaffeine -= 30;
                    if (consumedCaffeine < 0)
                    {
                        consumedCaffeine = 0;
                    }
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {consumedCaffeine} mg caffeine.");
        }
    }
}
