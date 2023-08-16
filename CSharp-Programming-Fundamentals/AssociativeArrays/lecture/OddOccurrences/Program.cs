using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Select(word => word.ToLower())
                .ToArray();

            Dictionary<string, int> occurancesByWord = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!occurancesByWord.ContainsKey(word))
                {
                    occurancesByWord.Add(word, 0);
                }

                occurancesByWord[word]++;
            }

            foreach (var kvp in occurancesByWord)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}
