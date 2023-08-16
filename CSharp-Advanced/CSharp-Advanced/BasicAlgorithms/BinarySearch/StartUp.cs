using System;
using System.Linq;

namespace BinarySearch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberToSearch = int.Parse(Console.ReadLine());

            int indexOfNumber = BinarySerach(numbers, numberToSearch);
            Console.WriteLine(indexOfNumber);
        }

        private static int BinarySerach(int[] numbers, int numberToSearch)
        {
            int low = 0;
            int high = numbers.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (numberToSearch > numbers[mid])
                {
                    low = mid + 1;
                }
                else if (numberToSearch < numbers[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
