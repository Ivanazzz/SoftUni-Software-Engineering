using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsOnGreenLimit = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            int carsPassed = 0;

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    if (queue.Count > carsOnGreenLimit)
                    {
                        for (int i = 0; i < carsOnGreenLimit; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                    else
                    {
                        while (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
