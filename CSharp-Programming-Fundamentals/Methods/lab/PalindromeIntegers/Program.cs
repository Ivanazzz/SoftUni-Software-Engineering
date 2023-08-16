using System;

namespace PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while(command != "END")
            {
                string numberAsString = command;

                Console.WriteLine(IsPalindrome(numberAsString).ToString().ToLower());
                command = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string numberAsString)
        {
            string numberAsStringReversed = "";

            for (int currentLetter = numberAsString.Length - 1; currentLetter >= 0; currentLetter--)
            {
                numberAsStringReversed += numberAsString[currentLetter];
            }

            if(numberAsString == numberAsStringReversed)
            {
                return true;
            }
            return false;
        }
    }
}
