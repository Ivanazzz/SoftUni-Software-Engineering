using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int asciiSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLargerOrEqualToAscii = (name, sum) 
                => name.Sum(x => x) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getName = 
                (names, ascii, func) => names
                                            .Where(x => func(x, ascii))
                                            .FirstOrDefault();

            var name = getName(names, asciiSum, isLargerOrEqualToAscii);
            Console.WriteLine(name);
        }
    }
}
