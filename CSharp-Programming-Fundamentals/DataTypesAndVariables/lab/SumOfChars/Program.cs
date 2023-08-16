using System;

namespace SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < numberOfChars; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sum += (int)currentChar;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
