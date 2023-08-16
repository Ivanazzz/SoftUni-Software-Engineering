using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> occurencesByNumber  = new SortedDictionary<double, int>();

            foreach (int number in numbers)
            {
                if (occurencesByNumber.ContainsKey(number))
                {
                    occurencesByNumber[number]++;
                }
                else
                {
                    occurencesByNumber.Add(number, 1);
                }
            }

            foreach (var kvp in occurencesByNumber)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
