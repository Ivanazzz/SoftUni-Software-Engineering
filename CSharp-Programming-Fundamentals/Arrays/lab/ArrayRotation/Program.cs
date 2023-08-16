using System;
using System.Linq;

namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < numberOfRotations; rotation++)
            {
                int temp = numbers[0];
                for (int operations = 0; operations < numbers.Length - 1; operations++)
                {
                    numbers[operations] = numbers[operations + 1];
                }
                numbers[numbers.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
