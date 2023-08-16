using System;
using System.Linq;

namespace HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            int lastPosition = 0;
            string[] command = Console.ReadLine().Split();
            while(command[0] != "Love!")
            {
                int jumpLengthIndex = int.Parse(command[1]);
                int currentPosition = lastPosition + jumpLengthIndex;
                if (jumpLengthIndex > neighborhood.Length - 1 || currentPosition > neighborhood.Length - 1)
                {
                    currentPosition = 0;
                }

                if(neighborhood[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    neighborhood[currentPosition] -= 2;
                    if(neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }

                lastPosition = currentPosition;

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {lastPosition}.");

            int housesFailed = 0;
            bool isValid = true;
            foreach (int house in neighborhood)
            {
                if(house != 0)
                {
                    isValid = false;
                    housesFailed++;
                }

            }

            if(isValid)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {housesFailed} places.");
            }
        }
    }
}
