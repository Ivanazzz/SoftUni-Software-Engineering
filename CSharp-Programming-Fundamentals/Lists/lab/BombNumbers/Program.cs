using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();
            int BombNumber = int.Parse(command[0]);
            int power = int.Parse(command[1]);

            int totalBombsToRemove = power * 2 + 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                int target = numbers[i];

                if(target == BombNumber)
                {
                    NumberToBomb(numbers, power, i);
                }
            }

            Console.WriteLine(numbers.Sum());
        }

        private static void NumberToBomb(List<int> numbers, int power, int index)
        {
            int start = Math.Max(0, index - power);
            int end = Math.Min(numbers.Count - 1, index + power);

            for (int i = start; i <= end; i++)
            {
                numbers[i] = 0;
            }
        }
    }
}
