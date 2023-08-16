using System;
using System.Linq;

namespace CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (x, y) => customComparator(x, y));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
