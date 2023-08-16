using System;
using System.Linq;

namespace ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while(command != "end")
            {
                string[] tokens = command.Split();
                string operation = tokens[0];

                switch (operation)
                {
                    case "swap":
                        int firstIndexToSwap = int.Parse(tokens[1]);
                        int secondIndexToSwap = int.Parse(tokens[2]);
                        SwapElements(firstIndexToSwap, secondIndexToSwap, numbers);
                        break;
                    case "multiply":
                        int firstIndexToMultiply = int.Parse(tokens[1]);
                        int secondIndexToMultiply = int.Parse(tokens[2]);
                        MultiplyElements(firstIndexToMultiply, secondIndexToMultiply, numbers);
                        break;
                    case "decrease":
                        DecreaseElements(numbers);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void SwapElements(int firstIndexToSwap, int secondIndexToSwap, int[] numbers)
        {
            int tempElement = numbers[firstIndexToSwap];
            numbers[firstIndexToSwap] = numbers[secondIndexToSwap];
            numbers[secondIndexToSwap] = tempElement;
        }

        private static void MultiplyElements(int firstIndexToMultiply, int secondIndexToMultiply, int[] numbers)
        {
            numbers[firstIndexToMultiply] = numbers[firstIndexToMultiply] * numbers[secondIndexToMultiply];
        }

        private static void DecreaseElements(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
        }
    }
}
