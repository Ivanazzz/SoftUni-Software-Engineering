using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> valueBySword = new Dictionary<int, string>()
            {
                {70, "Gladius" },
                {80, "Shamshir" },
                {90, "Katana" },
                {110, "Sabre" },
                {150, "Broadsword" },
            };

            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            SortedDictionary<string, int> swordsCount = new SortedDictionary<string, int>();
            int totalNumberOfSwords = 0;

            while (steel.Any() && carbon.Any())
            {
                int sum = steel.Dequeue() + carbon.Peek();

                if (valueBySword.ContainsKey(sum))
                {
                    string currentSword = valueBySword[sum];

                    carbon.Pop();
            
                    if (!swordsCount.ContainsKey(currentSword))
                    {
                        swordsCount.Add(currentSword, 0);
                    }

                    swordsCount[currentSword]++;
                    totalNumberOfSwords++;
                }
                else
                {
                    int tempCarbon = carbon.Pop() + 5;
                    carbon.Push(tempCarbon);
                }
            }

            Print(totalNumberOfSwords, steel, carbon, swordsCount);
        }

        private static void Print(int totalNumberOfSwords, Queue<int> steel, Stack<int> carbon, SortedDictionary<string, int> swordsCount)
        {
            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swordsCount)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
