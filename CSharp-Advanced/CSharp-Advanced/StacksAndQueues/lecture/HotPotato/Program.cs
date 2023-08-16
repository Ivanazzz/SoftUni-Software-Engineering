using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            int tosses = 1;

            while (queue.Count > 1)
            {
                string currentKid = queue.Dequeue();
                if (tosses == n)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    tosses = 1;
                    continue;
                }

                tosses++;
                queue.Enqueue(currentKid);
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
