using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> prices = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .ToList();

            Func<decimal, decimal> vatAdder = p => p + p * 0.2m;
            prices = prices.Select(vatAdder).ToList();

            prices.ForEach(p => Console.WriteLine($"{p:f2}"));
        }
    }
}
