using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            numbers = numbers.OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
} 
