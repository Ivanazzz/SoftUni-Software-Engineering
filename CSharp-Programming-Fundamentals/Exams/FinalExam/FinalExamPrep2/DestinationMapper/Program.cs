using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            string destinations = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matchedDestinations = regex.Matches(destinations);

            List<string> finalDestinations = new List<string>();
            int travelPoints = 0;

            foreach (Match match in matchedDestinations)
            {
                finalDestinations.Add(match.Groups["destination"].Value);
                travelPoints += match.Groups["destination"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", finalDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
