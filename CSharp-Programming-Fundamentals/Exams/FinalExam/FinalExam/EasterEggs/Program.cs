using System;
using System.Text.RegularExpressions;

namespace EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"[@#]+(?<color>[a-z]{3,})[@#]+([^[A-Za-z0-9]+]?)?\/+(?<amount>[0-9]+)\/+";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"You found {match.Groups["amount"].Value} {match.Groups["color"].Value} eggs!");
            }
        }
    }
}
