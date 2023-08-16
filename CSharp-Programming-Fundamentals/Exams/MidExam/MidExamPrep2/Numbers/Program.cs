using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            double averageValue = numbers.Sum() / numbers.Length;
            List<int> newNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if(number > averageValue)
                {
                    newNumbers.Add(number);
                }
            }

            newNumbers.Sort();
            newNumbers.Reverse();

            for (int i = newNumbers.Count - 1; i >= 5; i--)
            {
                newNumbers.Remove(newNumbers[i]);
            }

            if(newNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", newNumbers));
                Environment.Exit(0);
            }

            Console.WriteLine("No");
        }
    }
}
