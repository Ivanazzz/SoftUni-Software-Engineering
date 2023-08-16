using System;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumNumbers = 0;

            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                sumNumbers += num;

                if (sumNumbers >= number)
                {
                    Console.WriteLine(sumNumbers);
                    break;
                }
            }
        }
    }
}
