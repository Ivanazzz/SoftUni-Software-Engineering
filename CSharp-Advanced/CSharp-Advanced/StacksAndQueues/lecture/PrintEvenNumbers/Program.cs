using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0));

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
