using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int taskValueToKill = int.Parse(Console.ReadLine());

            while (tasks.Any() && threads.Any())
            {
                if (tasks.Peek() == taskValueToKill)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Peek()}");
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
