using System;
using System.Numerics;
using System.Text;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            int remainder = 0;

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                char lastNum = firstNumber[i];
                int lastNumAsDigit = int.Parse(lastNum.ToString());

                int result = lastNumAsDigit * secondNumber + remainder;

                sb.Insert(0, result % 10);
                remainder = result / 10;
            }

            if (remainder != 0)
            {
                sb.Insert(0, remainder);
            }

            Console.WriteLine(sb);
        }
    }
}
