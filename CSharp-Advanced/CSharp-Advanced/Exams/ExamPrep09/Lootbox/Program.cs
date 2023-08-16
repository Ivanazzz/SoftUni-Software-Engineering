using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int claimedItemsSum = 0;
            int neededItemsSum = 100;

            while (firstLootBox.Any() && secondLootBox.Any())
            {
                if ((firstLootBox.Peek() + secondLootBox.Peek()) % 2 == 0)
                {
                    claimedItemsSum += firstLootBox.Dequeue() + secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (!firstLootBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondLootBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItemsSum >= neededItemsSum)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
