using System;

namespace Sequence2kPlus1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int i = 1;

            while (i <= number)
            {
                Console.WriteLine(i);
                i = (i * 2) + 1;
            }
        }
    }
}
