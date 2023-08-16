using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> printNames = (name) => Console.WriteLine($"Sir {name}");

            names.ForEach(printNames);
        }
    }
}
