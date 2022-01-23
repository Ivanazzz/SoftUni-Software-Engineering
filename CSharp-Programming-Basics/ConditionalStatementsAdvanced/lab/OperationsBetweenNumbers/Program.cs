using System;

namespace OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char command = char.Parse(Console.ReadLine());
            double result = 0;

            switch (command)
            {
                case '+':
                    result = num1 + num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - odd");
                    }
                    break;
                case '-':
                    result = num1 - num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - odd");
                    }
                    break;
                case '*':
                    result = num1 * num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - odd");
                    }
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / Convert.ToDouble(num2);
                        Console.WriteLine($"{num1} / {num2} = {result:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    break;
                case '%':
                    if (num2 != 0)
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} % {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    break;
            }

        }
    }
}
