using System;

namespace RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());
            bool isSpecialNum = false;

            for (int number = 1; number <= numberCount; number++)
            {
                int numberCopy = number;
                int sum = 0;

                while (numberCopy > 0)
                {
                    sum += numberCopy % 10;
                    numberCopy = numberCopy / 10;
                }

                
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", number, isSpecialNum);
            }
        }
    }
}
