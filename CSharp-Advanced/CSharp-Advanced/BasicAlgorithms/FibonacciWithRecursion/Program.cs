using System;

namespace FibonacciWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fibonacci = Fibonacci(8);
            Console.WriteLine(fibonacci);
        }

        private static int Fibonacci(int position)
        {
            if (position == 0)
            {
                return 0;
            }
            else if (position == 1)
            {
                return 1;
            }

            int previous = Fibonacci(position - 1);
            int secondPrevious = Fibonacci(position - 2);

            return previous + secondPrevious;
        }
    }
}
