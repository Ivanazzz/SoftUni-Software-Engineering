using System;
using System.Linq;

namespace ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int shotTargets = 0;

            string command = Console.ReadLine();
            while(command != "End")
            {
                int currentIndex = int.Parse(command);
                if(currentIndex >= 0 && currentIndex < targets.Length)
                {
                    if(targets[currentIndex] != -1)
                    {
                        int shotValue = targets[currentIndex];
                        targets[currentIndex] = -1;
                        shotTargets++;

                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] != -1)
                            {
                                if (targets[i] > shotValue)
                                {
                                    targets[i] -= shotValue;
                                }
                                else
                                {
                                    targets[i] += shotValue;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.Write($"Shot targets: {shotTargets} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
