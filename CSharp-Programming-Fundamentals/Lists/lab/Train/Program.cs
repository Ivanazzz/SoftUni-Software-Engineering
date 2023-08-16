using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacityOfAWagon = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] tokens = command.Split();
                int passengers = 0;
                if(tokens.Length == 2)
                {
                    passengers = int.Parse(tokens[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    passengers = int.Parse(command);

                    FindWagon(wagons, maxCapacityOfAWagon, passengers);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FindWagon(List<int> wagons, int maxCapacityOfAWagon, int passengers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i];
                if (currentWagon + passengers <= maxCapacityOfAWagon)
                {
                    wagons[i] += passengers;
                    break;
                }
            }
        }
    }
}
