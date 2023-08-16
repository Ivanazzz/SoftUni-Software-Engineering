using System;

namespace CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startChar = Char.Parse(Console.ReadLine());
            char endChar = Char.Parse(Console.ReadLine());

            ReturnCharacterSequence(startChar, endChar);
        }

        static void ReturnCharacterSequence(char startChar, char endChar)
        {
            int start = Math.Min(startChar, endChar);
            int end = Math.Max(startChar, endChar);

            for (int i = start + 1; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }
            return;
        }
    }
}
