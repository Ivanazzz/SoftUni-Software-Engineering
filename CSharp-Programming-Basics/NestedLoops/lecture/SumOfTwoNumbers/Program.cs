using System;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combination = 0;
            bool isValid = false;
            int num1 = 0;
            int num2 = 0;


            for (int x = startNumber; x <= finalNumber; x++)
            {
                for (int y = startNumber; y <= finalNumber; y++)
                {
                    num1 = x;
                    num2 = y;
                    combination++;

                    if (num1 + num2 == magicNumber)
                    {
                        isValid = true;
                        break;
                    }
                }

                if (isValid)
                {
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Combination N:{combination} ({num1} + {num2} = {magicNumber})");
            }
            else
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");
            }
        }
    }
}
