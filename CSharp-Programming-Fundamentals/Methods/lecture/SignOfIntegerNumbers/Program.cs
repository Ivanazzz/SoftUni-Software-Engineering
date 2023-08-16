using System;

namespace SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintNumberType(number);
        }

        static void PrintNumberType(int number)
        {
            if(number == 0)
            {
                Console.WriteLine($"The number {number} is zero. ");
            }
            else if(number > 0)
            {
                Console.WriteLine($"The number {number} is positive. ");
            }
            else
            {
                Console.WriteLine($"The number {number} is negative. ");
            }
        }
    }
}
