using System;

namespace AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());    
            char endChar = char.Parse(Console.ReadLine());    
            string input = Console.ReadLine();

            int startCharAsNumber = (int)startChar;
            int endCharAsNumber = (int)endChar;

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currentCharAsNumber = (int)input[i];

                if (currentCharAsNumber > startCharAsNumber && currentCharAsNumber < endCharAsNumber)
                {
                    sum += currentCharAsNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
