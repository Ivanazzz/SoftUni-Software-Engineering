using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottlesInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsInfo);
            Stack<int> bottles = new Stack<int>(bottlesInfo);

            int wastedLittersOfWater = 0;

            while (cups.Any() && bottles.Any())
            {
                wastedLittersOfWater = FillCups(cups, bottles, wastedLittersOfWater);
            }

            if (!bottles.Any())
            {
                    Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
                    Environment.Exit(0);
            }

            Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }

        private static int FillCups(Queue<int> cups, Stack<int> bottles, int wastedLittersOfWater)
        {
            int currentBottle = bottles.Pop();
            int currentCup = cups.Peek();

            if (currentBottle >= currentCup)
            {
                wastedLittersOfWater += currentBottle - currentCup;
                cups.Dequeue();
            }
            else
            {
                currentCup -= currentBottle;

                while (currentCup > 0 && bottles.Any())
                {
                    currentBottle = bottles.Pop();

                    if (currentBottle > currentCup)
                    {
                        wastedLittersOfWater += currentBottle - currentCup;
                    }

                    currentCup -= currentBottle;
                }

                cups.Dequeue();
            }

            return wastedLittersOfWater;
        }
    }
}
