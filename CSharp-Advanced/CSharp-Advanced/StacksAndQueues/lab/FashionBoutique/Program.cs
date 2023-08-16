using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());

            int racksCount = 0;
            int currentRackCapacity = 0;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + currentRackCapacity < rackCapacity)
                {
                    currentRackCapacity += clothes.Pop();
                }
                else if (clothes.Peek() + currentRackCapacity == rackCapacity)
                {
                    clothes.Pop();
                    racksCount++;
                    currentRackCapacity = 0;
                }
                else
                {
                    racksCount++;
                    currentRackCapacity = 0;
                }
            }

            if (currentRackCapacity > 0)
            {
                racksCount++;
            }

            Console.WriteLine(racksCount);
        }
    }
}
