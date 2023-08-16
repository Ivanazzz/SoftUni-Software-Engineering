using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int maxSequence = 0;
            int element = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if(numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if(counter > maxSequence)
                    {
                        maxSequence = counter;
                        element = numbers[i];
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < maxSequence; i++)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
