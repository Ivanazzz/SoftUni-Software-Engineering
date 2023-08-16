using System;

namespace StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberCopy = number;
            int sum = 0;

            while(numberCopy != 0)
            {
                int product = 1;
                int currentDigit = numberCopy % 10;
                int i = 1;
                while (i <= currentDigit)
                {
                    product *= i;
                    i++;
                }
                sum += product;
                numberCopy /= 10;
            }

            string result = sum == number ? "yes" : "no";
            Console.WriteLine(result);
        }
    }
}
