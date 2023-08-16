using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int, bool> isDivisible = (numbersArray, currentNumber) =>
            {
                foreach (int number in numbersArray)
                {
                    if (currentNumber % number != 0)
                    {
                        return false;
                    }    
                }

                return true;
            };

            int end = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> outputNumbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                if (isDivisible(dividers, i))
                {
                    outputNumbers.Add(i);
                }
            }

            Console.WriteLine(String.Join(' ', outputNumbers));
        }
    }
}
