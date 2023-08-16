using System;
using System.Linq;

namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            SearchForVowels(inputText);
        }

        static void SearchForVowels(string inputText)
        {
            Console.WriteLine(inputText.Count(vowels => "aouei".Contains(vowels)));
        }
    }
}
