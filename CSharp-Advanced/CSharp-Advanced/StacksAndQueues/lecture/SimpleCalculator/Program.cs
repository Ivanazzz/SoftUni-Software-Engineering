using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();

            foreach (string item in expression)
            {
                stack.Push(item);

                if (stack.Count == 3)
                {
                    int firstNumber = int.Parse(stack.Pop());
                    string sign = stack.Pop();
                    int secondNumber = int.Parse(stack.Pop());
                    int result = 0;

                    if (sign == "+")
                    {
                        result = firstNumber + secondNumber;
                    }
                    else
                    {
                        result = secondNumber - firstNumber;
                    }

                    stack.Push(result.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
