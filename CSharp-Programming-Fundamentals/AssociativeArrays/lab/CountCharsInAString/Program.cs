using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> characterOccurances = new Dictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (symbol != ' ')
                {
                    if (!characterOccurances.ContainsKey(symbol))
                    {
                        characterOccurances.Add(symbol, 0);
                    }

                    characterOccurances[symbol]++;
                }
            }

            foreach (var kvp in characterOccurances)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
