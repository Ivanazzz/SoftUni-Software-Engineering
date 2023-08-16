using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] condensed = new int[numbers.Length - 1];

            while (numbers.Length > 1)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];

                    if (i == numbers.Length - 2)
                    {
                        numbers = condensed;
                        condensed = new int[numbers.Length - 1];
                    }
                }
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
