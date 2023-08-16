using System;
using System.Linq;

namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                bool currIterationNumIsBigger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[i] <= numbers[j])
                    {
                        currIterationNumIsBigger = false;
                        break;
                    }
                }

                if(currIterationNumIsBigger)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }
    }
}
