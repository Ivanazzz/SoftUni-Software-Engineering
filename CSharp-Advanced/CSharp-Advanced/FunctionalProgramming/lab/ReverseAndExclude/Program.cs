using System;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (x, y) => x % y != 0;

            numbers = numbers.Where(x => isDivisible(x, divider)).ToArray();

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
