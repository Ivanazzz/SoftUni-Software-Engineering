using System;

namespace TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int charNumber = int.Parse(Console.ReadLine());

            for (int i = (int)'a'; i <= (int)'a' + charNumber - 1; i++)
            {
                for (int j = (int)'a'; j <= (int)'a' + charNumber - 1; j++)
                {
                    for (int k = (int)'a'; k <= (int)'a' + charNumber - 1; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
