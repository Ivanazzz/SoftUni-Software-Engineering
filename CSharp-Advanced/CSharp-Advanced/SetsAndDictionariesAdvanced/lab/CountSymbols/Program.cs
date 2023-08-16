using System;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbolsCount = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (char symbol in input)
            {
                if (!symbolsCount.ContainsKey(symbol))
                {
                    symbolsCount.Add(symbol, 0);
                }
                symbolsCount[symbol]++;
            }

            foreach (var item in symbolsCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
