using System;

namespace TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(number);
        }

        static void PrintTribonacciSequence(int number)
        {
            if (number == 1)
            {
                Console.WriteLine(1);
            }
            else if (number == 2)
            {
                Console.WriteLine("1 1");
            }
            else if (number == 3)
            {
                Console.WriteLine("1 1 2");
            }
            else
            {
                int[] tribonacci = new int[number];
                tribonacci[0] = 1;
                tribonacci[1] = 1;
                tribonacci[2] = 2;

                for (int i = 3; i < tribonacci.Length; i++)
                {
                    tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
                }

                for (int i = 0; i < tribonacci.Length; i++)
                {
                    Console.Write($"{tribonacci[i]} ");
                }
            }
        }
    }
}