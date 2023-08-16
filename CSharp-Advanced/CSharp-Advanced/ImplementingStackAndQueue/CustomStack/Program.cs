using System;

namespace CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Print();

            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Print();

            Console.WriteLine(stack.Peek());

            Console.WriteLine();

            stack.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
