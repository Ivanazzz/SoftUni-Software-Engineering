namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int CAPACITY = 10;

        private static List<int> numbers;

        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            numbers = new List<int>();

            while (numbers.Count < CAPACITY)
            {
                try
                {
                    ReadNumber(ref start, end);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ReadNumber(ref int start, int end)
        {
            string input = Console.ReadLine();

            int number = 0;
            bool isNumber = int.TryParse(input, out number);
            if (!isNumber)
            {
                throw new FormatException("Invalid Number!");
            }
            else if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            numbers.Add(number);
            start = number;
        }
    }
}
