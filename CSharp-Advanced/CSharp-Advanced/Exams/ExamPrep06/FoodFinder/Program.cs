using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>()
            {
                { "pear", "pear".ToList() },
                { "flour", "flour".ToList() },
                { "pork", "pork".ToList() },
                { "olive", "olive".ToList() },
            };

            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            List<string> wordsFound = new List<string>();
            int index = 1;

            while (consonants.Any())
            {
                if (index <= vowels.Count)
                {
                    char currentVowel = vowels.Dequeue();
                    vowels.Enqueue(currentVowel);
                    index++;

                    foreach (var word in words)
                    {
                        word.Value.RemoveAll(x => x == currentVowel);
                    }
                }

                char currentConsonant = consonants.Pop();

                foreach (var word in words)
                {
                    word.Value.RemoveAll(x => x == currentConsonant);
                }
            }

            foreach (var word in words)
            {
                if (word.Value.Count == 0)
                {
                    wordsFound.Add(word.Key);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
