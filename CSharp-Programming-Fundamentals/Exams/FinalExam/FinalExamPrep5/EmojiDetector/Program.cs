using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string emojisPattern = @"(\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";

            MatchCollection emojiMatches = Regex.Matches(text, emojisPattern);
            MatchCollection digitsMatches = Regex.Matches(text, digitsPattern);

            long treshold = 1;
            foreach (Match digit in digitsMatches)
            {
                treshold *= int.Parse(digit.Value);
            }

            Console.WriteLine($"Cool threshold: {treshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojiMatches)
            {
                string currentEmoji = emoji.Groups["emoji"].Value;
                long emojiTreshold = currentEmoji.ToCharArray().Sum(c => c);

                if (emojiTreshold >= treshold)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }
    }
}
