using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                numbers[i] = numbers[i] + numbers[numbers.Count - 1];
                numbers.Remove(numbers[numbers.Count - 1]);
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
