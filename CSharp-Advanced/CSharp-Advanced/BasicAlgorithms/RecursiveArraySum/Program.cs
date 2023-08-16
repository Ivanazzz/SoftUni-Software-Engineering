using System;
using System.Linq;

namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(elements, 0));
        }

        private static int Sum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            int result = array[index] + Sum(array, index + 1);

            return result;
        }
    }
}
