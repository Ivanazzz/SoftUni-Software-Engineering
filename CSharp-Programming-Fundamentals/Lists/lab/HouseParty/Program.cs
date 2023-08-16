using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for(int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string currentName = command[0];

                if(command[2] == "going!")
                {
                    if(guests.Contains(currentName))
                    {
                        Console.WriteLine($"{currentName} is already in the list!");
                    }
                    else
                    {
                        guests.Add(currentName);
                    }
                }
                else if(command[2] == "not")
                {
                    if(guests.Contains(currentName))
                    {
                        guests.Remove(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"{currentName} is not in the list!");
                    }
                }
            }

            foreach (string name in guests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
