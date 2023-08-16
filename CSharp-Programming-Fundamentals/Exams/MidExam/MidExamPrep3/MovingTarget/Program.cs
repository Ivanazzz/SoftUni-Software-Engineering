using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] tokens = command.Split();
                string operation = tokens[0];
                int index = int.Parse(tokens[1]);

                switch (operation)
                {
                    case "Shoot":
                        int power = int.Parse(tokens[2]);
                        ShootTarget(index, power, targets);
                        break;
                    case "Add":
                        int value = int.Parse(tokens[2]);
                        AddTarget(index, value, targets);
                        break;
                    case "Strike":
                        int radius = int.Parse(tokens[2]);
                        StrikeTarget(index, radius, targets);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        private static void ShootTarget(int index, int power, List<int> targets)
        {
            if(index >= 0 && index < targets.Count)
            {
                targets[index] -= power;
                if(targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }

        private static void AddTarget(int index, int value, List<int> targets)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void StrikeTarget(int index, int radius, List<int> targets)
        {
            if (index >= 0 && index <= targets.Count)
            {
                int startIndex = index - radius;
                int endIndex = index + radius;

                if(startIndex < 0 || endIndex > targets.Count - 1)
                {
                    Console.WriteLine("Strike missed!");
                    return;
                }

                for (int target = endIndex; target >= startIndex; target--)
                {
                    targets.RemoveAt(target);
                }
            }
        }
    }
}
