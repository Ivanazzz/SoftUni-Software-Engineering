using System;
using System.Linq;

namespace EvenAndOddSubtraction
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

            int evenNumbersSum = 0;
            int oddNumbersSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    evenNumbersSum += numbers[i];
                }
                else
                {
                    oddNumbersSum += numbers[i];
                }
            }

            Console.WriteLine(evenNumbersSum - oddNumbersSum);
        }
    }
}
