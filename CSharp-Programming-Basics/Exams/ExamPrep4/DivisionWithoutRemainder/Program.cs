using System;

namespace DivisionWithoutRemainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 1; i <= numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p1++;
                }
                if (number % 3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }
            }

            double p1Percentage = p1 * 1.00 / numbersCount * 100;
            double p2Percentage = p2 * 1.00 / numbersCount * 100;
            double p3Percentage = p3 * 1.00 / numbersCount * 100;

            Console.WriteLine($"{p1Percentage:F2}%");
            Console.WriteLine($"{p2Percentage:F2}%");
            Console.WriteLine($"{p3Percentage:F2}%");
        }
    }
}
