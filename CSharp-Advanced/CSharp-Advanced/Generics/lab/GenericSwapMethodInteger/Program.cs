using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                data.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexesToSwap = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(data, indexesToSwap[0], indexesToSwap[1]);

            foreach (int item in data)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static void Swap<T>(List<T> data, int firstIndex, int secondIndex)
        {
            T temp = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = temp;
        }
    }
}
