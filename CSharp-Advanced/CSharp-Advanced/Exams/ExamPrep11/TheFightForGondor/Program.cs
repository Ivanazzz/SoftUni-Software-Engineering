using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());
            List<int> platesOfDefense = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int wave = 1; wave <= wavesOfOrcs; wave++)
            {
                Stack<int> powerOfWarrior = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

                if (wave % 3 == 0)
                {
                    platesOfDefense.Add(int.Parse(Console.ReadLine()));
                }

                while (powerOfWarrior.Any())
                {
                    if (platesOfDefense.Count == 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine($"Orcs left: {string.Join(", ", powerOfWarrior)}");

                        Environment.Exit(0);
                    }

                    if (powerOfWarrior.Peek() < platesOfDefense[0])
                    {
                        platesOfDefense[0] -= powerOfWarrior.Pop();
                    }
                    else if (powerOfWarrior.Peek() == platesOfDefense[0])
                    {
                        platesOfDefense.RemoveAt(0);
                        powerOfWarrior.Pop();
                    }
                    else
                    {
                        int temp = powerOfWarrior.Pop() - platesOfDefense[0];
                        powerOfWarrior.Push(temp);
                        platesOfDefense.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", platesOfDefense)}");
        }
    }
}
