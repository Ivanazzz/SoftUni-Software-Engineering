using System;

namespace LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = (int)firstChar; i <= (int)secondChar; i++)
            {
                if (i == (int)thirdChar)
                {
                    continue;
                }
                for (int j = (int)firstChar; j <= (int)secondChar; j++)
                {
                    if (j == (int)thirdChar)
                    {
                        continue;
                    }
                    for (int l = (int)firstChar; l <= (int)secondChar; l++)
                    {
                        if (l == (int)thirdChar)
                        {
                            continue;
                        }
                        counter++;
                        Console.Write($"{(char)i}{(char)j}{(char)l} ");
                    }
                }
            }

            Console.Write(counter);
        }
    }
}
