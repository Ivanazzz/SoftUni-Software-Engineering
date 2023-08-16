using System;

namespace DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            if(dataType == "int")
            {
                int number = int.Parse(Console.ReadLine());
                MethodWithInteger(number);
            }
            else if(dataType == "real")
            {
                double number = double.Parse(Console.ReadLine());
                MethodWithDouble(number);
            }
            else if(dataType == "string")
            {
                string str = Console.ReadLine();
                MethodWithString(str);
            }
        }

        static void MethodWithString(string str)
        {
            Console.WriteLine($"${str}$");
        }

        static void MethodWithDouble(double number)
        {
            double result = number * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        static void MethodWithInteger(int number)
        {
            int result = number * 2;
            Console.WriteLine(result);
        }
    }
}
