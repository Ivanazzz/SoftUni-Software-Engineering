using System;

namespace RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        private static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            int result = number * Factorial(number - 1);

            return result;
        }
    }
}
