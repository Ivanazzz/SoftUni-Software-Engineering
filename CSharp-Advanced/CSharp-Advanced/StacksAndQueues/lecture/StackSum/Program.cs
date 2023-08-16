using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        int firstNumber = int.Parse(command[1]);
                        int secondNumber = int.Parse(command[2]);

                        stack.Push(firstNumber);
                        stack.Push(secondNumber);
                        break;
                    case "remove":
                        int count = int.Parse(command[1]);

                        if (count <= stack.Count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }

                command = Console.ReadLine().ToLower().Split();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
