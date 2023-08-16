using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> stops = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                stops.Enqueue(info);
            }
            int index = 0;

            while (true)
            {
                int tankCapacity = 0;
                bool flag = true;

                foreach (var item in stops)
                {
                    tankCapacity += item[0];

                    if (tankCapacity - item[1] >= 0)
                    {
                        tankCapacity -= item[1];
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }

                if (flag)
                {
                    Console.WriteLine(index);
                    break;
                }
                else
                {
                    int[] temp = stops.Dequeue();
                    stops.Enqueue(temp);
                    index++;
                }
            }
        }
    }
}