using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .ToArray();

            Dictionary<double, int> numberOccurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberOccurrences.ContainsKey(number))
                {
                    numberOccurrences.Add(number, 0);
                }

                numberOccurrences[number]++;
            }

            foreach (var item in numberOccurrences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
