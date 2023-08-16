using System;

namespace FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            FactorialDivision(firstNumber, secondNumber);
        }

        static void FactorialDivision(int firstNumber, int secondNumber)
        {
            double firstFactorial = 1;
            for (int currentNumber = 1; currentNumber <= firstNumber; currentNumber++)
            {
                firstFactorial *= currentNumber;
            }

            double secondFactorial = 1;
            for (int currentNumber = 1; currentNumber <= secondNumber; currentNumber++)
            {
                secondFactorial *= currentNumber;
            }

            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:f2}");
        }
    }
}
