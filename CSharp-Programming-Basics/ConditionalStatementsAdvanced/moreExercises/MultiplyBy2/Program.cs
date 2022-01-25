using System;

namespace MultiplyBy2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double number = double.Parse(Console.ReadLine());
                if (number < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
                double result = number * 2;
                Console.WriteLine($"Result: {result:F2}");
            }
        }
    }
}
