using System;

namespace NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int biggestNum = int.MinValue;
            int smallestNum = int.MaxValue;

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (biggestNum < number)
                {
                    biggestNum = number;
                }
                if (smallestNum > number)
                {
                    smallestNum = number;
                }
            }

            Console.WriteLine($"Max number: {biggestNum}");
            Console.WriteLine($"Min number: {smallestNum}");
        }
    }
}
