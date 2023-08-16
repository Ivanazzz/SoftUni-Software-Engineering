using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequenceOfParentheses = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            if (sequenceOfParentheses.Length % 2 == 0)
            {
                for (int i = 0; i < sequenceOfParentheses.Length; i++)
                {
                    char currentParentheses = sequenceOfParentheses[i];

                    switch (currentParentheses)
                    {
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        default:
                            stack.Push(currentParentheses);
                            break;
                    }

                    if (!isValid)
                    {
                        break;
                    }
                }
            }
            else
            {
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("YES");
                Environment.Exit(0);
            }

            Console.WriteLine("NO");
        }
    }
}