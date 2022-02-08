using System;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    int result = x * y;
                    Console.WriteLine($"{x} * {y} = {result}");
                }
            }
        }
    }
}
