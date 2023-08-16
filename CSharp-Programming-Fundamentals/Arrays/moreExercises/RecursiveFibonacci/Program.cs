using System;

namespace RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedFibonacciNumber = int.Parse(Console.ReadLine());
            int[] fibonacci = new int[wantedFibonacciNumber];

            for (int i = 0; i < fibonacci.Length; i++)
            {
                if(i == 0 || i == 1)
                {
                    fibonacci[i] = 1;
                    continue;
                }

                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            Console.WriteLine(fibonacci[wantedFibonacciNumber - 1]);
        }
    }
}
