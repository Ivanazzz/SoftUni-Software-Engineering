using System;

namespace AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = Subtract(Add(firstNumber, secondNumber), thirdNumber);
            Console.WriteLine(result);
        }

        static int Add(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }

        static int Subtract(int sum, int thirdNumber)
        {
            int result = sum - thirdNumber;
            return result;
        }
    }
}
