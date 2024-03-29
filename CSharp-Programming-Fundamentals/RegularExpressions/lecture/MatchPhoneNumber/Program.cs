﻿using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\+359(?<separator>[-\s])2(\k<separator>)[0-9]{3}(\k<separator>)[0-9]{4}\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
