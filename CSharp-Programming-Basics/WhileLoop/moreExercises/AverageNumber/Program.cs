using System;

namespace AverageNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int numbersSum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbersSum += number;
            }

            double averageSum = numbersSum * 1.00 / numbersCount;
            Console.WriteLine($"{averageSum:F2}");
        }
    }
}
