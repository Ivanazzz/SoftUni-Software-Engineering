using System;

namespace SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfOddNumbers = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < countOfOddNumbers; i++)
            {
                int currentNumber = 1 + (i * 2);
                sum += currentNumber;
                Console.WriteLine(currentNumber);
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
