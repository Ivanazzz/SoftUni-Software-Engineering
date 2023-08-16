using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (foodQuantity >= queue.Peek())
                {
                    foodQuantity -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
