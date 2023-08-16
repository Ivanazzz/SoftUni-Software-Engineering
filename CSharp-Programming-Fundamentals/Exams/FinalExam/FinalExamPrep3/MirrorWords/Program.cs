using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|@)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matchedWords = regex.Matches(input);

            if (matchedWords.Count > 0)
            {
                Console.WriteLine($"{matchedWords.Count} word pairs found!");

                Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
                foreach (Match match in matchedWords)
                {
                    string firstWord = match.Groups["firstWord"].Value;
                    string secondWord = match.Groups["secondWord"].Value;
                    char[] secondWordReversed = secondWord.ToCharArray();
                    Array.Reverse(secondWordReversed);
                    string reversedSecondWord = new string(secondWordReversed);

                    if (firstWord == reversedSecondWord)
                    {
                        mirrorWords.Add(firstWord, secondWord);
                    }
                }

                if (mirrorWords.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirrorWords.Select(x => x.Key + " <=> " + x.Value).ToArray()));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
