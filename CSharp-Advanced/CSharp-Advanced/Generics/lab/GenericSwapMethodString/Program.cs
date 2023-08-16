using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = new List<string>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                data.Add(Console.ReadLine());
            }

            int[] indexesToSwap = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(data, indexesToSwap[0], indexesToSwap[1]);

            foreach (string item in data)
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
