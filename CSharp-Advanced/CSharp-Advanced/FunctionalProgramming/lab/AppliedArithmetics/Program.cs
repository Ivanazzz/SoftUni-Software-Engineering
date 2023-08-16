using System;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> add = x =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i]++;
                }
            };

            Action<int[]> multiply = x =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }
            };

            Action<int[]> subtract = x =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i]--;
                }
            };

            Action<int[]> print = x => Console.WriteLine(string.Join(' ', x));

            while (true)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    case "end":
                        Environment.Exit(0);
                        break;
                    case "add":
                        add(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
