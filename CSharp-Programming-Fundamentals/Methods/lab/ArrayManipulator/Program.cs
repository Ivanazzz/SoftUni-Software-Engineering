using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while(command[0] != "end")
            {
                switch(command[0])
                {
                    case "exchange":
                        int index = int.Parse(command[1]);
                        numbers = Exchange(numbers, index);
                        break;
                    case "max":
                    case "min":
                        FindMinMax(numbers, command[0], command[1]);
                        break;
                    case "first":
                    case "last":
                        FindEvenOdd(numbers, command[0], int.Parse(command[1]), command[2]);
                        break;
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static int[] Exchange(int[] numbers, int index)
        {
            if(index >= numbers.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }

            int[] exchangedNumbers = new int[numbers.Length];
            int currentIndex = 0;
            for (int i = index + 1; i < numbers.Length; i++)
            {
                exchangedNumbers[currentIndex] = numbers[i];
                currentIndex++;
            }
            for (int i = 0; i <= index; i++)
            {
                exchangedNumbers[currentIndex] = numbers[i];
                currentIndex++;
            }

            return exchangedNumbers;
        }

        private static void FindMinMax(int[] numbers, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOddEven = 1;

            if (evenOrOdd == "even") resultOddEven = 0;

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                if(numbers[currentIndex] % 2 == resultOddEven)
                {
                    if(minOrMax == "min" && min >= numbers[currentIndex])
                    {
                        min = numbers[currentIndex];
                        index = currentIndex;
                    }
                    else if(minOrMax == "max" && max <= numbers[currentIndex])
                    {
                        max = numbers[currentIndex];
                        index = currentIndex;
                    }
                }
            }

            Console.WriteLine(index > -1 ? index.ToString() : "No matches");
        }

        private static void FindEvenOdd(int[] numbers, string position, int numbersCount, string evenOrOdd)
        {
            if(numbersCount > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (numbersCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int resultEvenOdd = 1;
            if (evenOrOdd == "even") resultEvenOdd = 0;
            int count = 0;
            List<int> nums = new List<int>();   

            if(position == "first")
            {
                foreach (int currentNum in numbers)
                {
                    if(currentNum % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(currentNum);
                        if (count == numbersCount) break;
                    }
                }
            }
            else
            {
                for (int currentIndex = numbers.Length - 1; currentIndex >= 0; currentIndex--)
                {
                    if(numbers[currentIndex] % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(numbers[currentIndex]);
                        if (count == numbersCount) break;
                    }
                }

                nums.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
