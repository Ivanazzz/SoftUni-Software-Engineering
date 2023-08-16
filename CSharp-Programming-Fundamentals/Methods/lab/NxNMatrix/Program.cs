using System;

namespace NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintMatrix(number);
        }

        static void PrintMatrix(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int column = 1; column <= number; column++)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
