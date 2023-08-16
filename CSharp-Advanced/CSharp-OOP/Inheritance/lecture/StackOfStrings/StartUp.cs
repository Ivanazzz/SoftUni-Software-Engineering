using System;
using System.Collections.Generic;

namespace StackOfStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();


            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new List<string>() { "apple", "banana", "kiwi" });

            Console.WriteLine(stack.IsEmpty());

            stack.Pop();

            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
