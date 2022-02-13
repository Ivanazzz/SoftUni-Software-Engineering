using System;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());

            for (int number = 1111; number <= 9999; number++)
            {
                bool isValid = true;
                int currentNum = number;

                for (int digit = 0; digit < 4; digit++)
                {
                    int lastDigit = currentNum % 10;
                    if (n % lastDigit != 0)
                    {
                        isValid = false;
                    }
                    currentNum /= 10;
                }

                if (isValid)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
