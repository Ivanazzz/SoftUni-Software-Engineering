using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<string> command = Console.ReadLine()
                .Split()
                .ToList();

            bool isChanged = false;

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(command[1]);
                        numbers.Add(numberToAdd);
                        isChanged = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(command[1]);
                        numbers.Remove(numberToRemove);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        int indexToRemoveAt = int.Parse(command[1]);
                        numbers.RemoveAt(indexToRemoveAt);
                        isChanged = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsertAt = int.Parse(command[2]);
                        numbers.Insert(indexToInsertAt, numberToInsert);
                        isChanged = true;
                        break;
                    case "Contains":
                        int containedNumber = int.Parse(command[1]);
                        CheckContains(containedNumber, numbers);
                        break;
                    case "PrintEven":
                        PrintEvenNumbers(numbers);
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(numbers);
                        break;
                    case "GetSum":
                        PrintSum(numbers);
                        break;
                    case "Filter":
                        string condition = command[1];
                        int number = int.Parse(command[2]);
                        FilterNumbers(condition, number, numbers);
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToList();
            }

            if(isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void CheckContains(int containedNumber, List<int> numbers)
        {
            bool isContained = numbers.Contains(containedNumber);
            if (isContained)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintEvenNumbers(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                if(number % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }

        private static void PrintOddNumbers(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }

        private static void PrintSum(List<int> numbers)
        {
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }

        private static void FilterNumbers(string condition, int number, List<int> numbers)
        {
            switch(condition)
            {
                case "<":
                    List<int> lessThanNumbers = numbers.Where(num => num < number).ToList();
                    Console.WriteLine(string.Join(" ", lessThanNumbers));
                    break;
                case ">":
                    List<int> greaterThanNumbers = numbers.Where(num => num > number).ToList();
                    Console.WriteLine(string.Join(" ", greaterThanNumbers));
                    break;
                case ">=":
                    List<int> greaterThanOrEqualToNumbers = numbers.Where(num => num >= number).ToList();
                    Console.WriteLine(string.Join(" ", greaterThanOrEqualToNumbers));
                    break;
                case "<=":
                    List<int> lessThanOrEqualToNumbers = numbers.Where(num => num <= number).ToList();
                    Console.WriteLine(string.Join(" ", lessThanOrEqualToNumbers));
                    break;
            }
        }
    }
}
