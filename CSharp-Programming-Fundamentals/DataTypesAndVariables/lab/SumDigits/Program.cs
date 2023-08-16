using System;

namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int digitsSum = 0;
            while (number > 0)
            {
                digitsSum += number % 10;
                number /= 10;
            }

            Console.WriteLine(digitsSum);
        }
    }
}
