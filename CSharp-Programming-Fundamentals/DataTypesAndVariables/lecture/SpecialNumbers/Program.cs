using System;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberEnd = int.Parse(Console.ReadLine());

            for (int number = 1; number <= numberEnd; number++)
            {
                int numberCopy = number;
                int sum = 0;

                while (numberCopy != 0)
                {
                    sum += numberCopy % 10;
                    numberCopy /= 10;
                }

                if(sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{number} -> True");
                }
                else
                {
                    Console.WriteLine($"{number} -> False");
                }
            }
        }
    }
}
