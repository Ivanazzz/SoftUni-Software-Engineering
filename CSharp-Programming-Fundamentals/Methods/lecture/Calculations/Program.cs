using System;

namespace Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if(command == "add")
            {
                Addition(firstNumber, secondNumber);
            }
            else if(command == "multiply")
            {
                Multiplication(firstNumber, secondNumber);
            }
            else if(command == "subtract")
            {
                Subtraction(firstNumber, secondNumber);
            }
            else if(command == "divide")
            {
                Division(firstNumber, secondNumber);
            }
        }

        static void Addition(int firstNumber, int secondNumber)
        {
            int result = firstNumber + secondNumber;
            Console.WriteLine(result);
        }

        static void Multiplication(int firstNumber, int secondNumber)
        {
            int result = firstNumber * secondNumber;
            Console.WriteLine(result);
        }

        static void Subtraction(int firstNumber, int secondNumber)
        {
            int result = firstNumber - secondNumber;
            Console.WriteLine(result);
        }

        static void Division(int firstNumber, int secondNumber)
        {
            int result = firstNumber / secondNumber;
            Console.WriteLine(result);
        }
    }
}
