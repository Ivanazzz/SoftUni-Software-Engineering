using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split("|")
                .ToList();

            string command = Console.ReadLine();
            while(command != "Yohoho!")
            {
                string[] tokens = command.Split();
                string operation = tokens[0];

                switch (operation)
                {
                    case "Loot":
                        LootItems(tokens, treasureChest);
                        break;
                    case "Drop":
                        int index = int.Parse(tokens[1]);
                        DropItems(index, treasureChest);
                        break;
                    case "Steal":
                        int count = int.Parse(tokens[1]);
                        StealItems(count, treasureChest);
                        break;
                }

                command = Console.ReadLine();
            }

            if (treasureChest.Count != 0)
            {
                int sum = 0;
                for (int item = 0; item < treasureChest.Count; item++)
                {
                    sum += treasureChest[item].Length;
                }

                double averageGain = sum * 1.0 / treasureChest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }

        private static void LootItems(string[] tokens, List<string> treasureChest)
        {
            for (int token = 1; token < tokens.Length; token++)
            {
                if (!treasureChest.Contains(tokens[token]))
                {
                    treasureChest.Insert(0, tokens[token]);
                }
            }
        }

        private static void DropItems(int index, List<string> treasureChest)
        {
            if (index >= 0 && index < treasureChest.Count)
            {
                string currentItem = treasureChest[index];
                treasureChest.Remove(currentItem);
                treasureChest.Add(currentItem);
            }
        }

        private static void StealItems(int count, List<string> treasureChest)
        {
            if (count >= treasureChest.Count)
            {
                Console.WriteLine(string.Join(", ", treasureChest));
                treasureChest.Clear();
            }
            else
            {
                int start = treasureChest.Count - count;
                int end = treasureChest.Count - 1;
                List<string> stealedItems = new List<string>();
                for (int item = start; item <= end; item++)
                {
                    stealedItems.Add(treasureChest[item]);
                }

                treasureChest.RemoveRange(start, count);
                Console.WriteLine(string.Join(", ", stealedItems));
            }
        }
    }
}
