using System;

namespace MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(RaiseToPower(baseNumber, power));
        }

        static double RaiseToPower(double baseNumber, double power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}
