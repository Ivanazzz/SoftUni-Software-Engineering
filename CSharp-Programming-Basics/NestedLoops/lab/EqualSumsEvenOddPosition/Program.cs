using System;

namespace EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int number = firstNum; number <= secondNum; number++)
            {
                int evenDigitsSum = 0;
                int oddDigitsSum = 0;

                string currentNum = number.ToString();

                for (int digit = 0; digit < currentNum.Length; digit++)
                {
                    if (digit % 2 != 0)
                    {
                        evenDigitsSum += currentNum[digit];
                    }
                    else
                    {
                        oddDigitsSum += currentNum[digit];
                    }
                }

                if (evenDigitsSum == oddDigitsSum)
                {
                    Console.Write(currentNum + " ");
                }
            }
        }
    }
}
