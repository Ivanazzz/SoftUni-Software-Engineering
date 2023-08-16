using System;

namespace RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberEnd = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= numberEnd; currentNumber++)
            {
                bool isValid = true;
                for (int divider = 2; divider < currentNumber; divider++)
                {
                    if (currentNumber % divider == 0)
                    {
                        isValid = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", currentNumber, isValid.ToString().ToLower());
            }
        }
    }
}
