using System;

namespace TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            FindTopNumber(endValue);
        }

        static void FindTopNumber(int endValue)
        {
            for (int currentNumber = 8; currentNumber <= endValue; currentNumber++)
            {
                int sumOfDigits = 0;
                int oddDigitsCount = 0;
                int numberCopy = currentNumber;

                while(numberCopy > 0)
                {
                    int currentDigit = numberCopy % 10;
                    sumOfDigits += currentDigit;

                    if(currentDigit % 2 != 0)
                    {
                        oddDigitsCount++;
                    }

                    numberCopy /= 10;
                }

                if(sumOfDigits % 8 == 0 && oddDigitsCount >= 1)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }
    }
}
