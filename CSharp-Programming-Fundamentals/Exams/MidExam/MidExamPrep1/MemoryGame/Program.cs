using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int moves = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (sequenceOfElements.Count > 0)
                {
                    string[] tokens = command.Split();
                    int firstIndex = int.Parse(tokens[0]);
                    int secondIndex = int.Parse(tokens[1]);
                    moves++;

                    if ((firstIndex == secondIndex) ||
                        (firstIndex < 0 || firstIndex >= sequenceOfElements.Count) ||
                        (secondIndex < 0 || secondIndex >= sequenceOfElements.Count))
                    {
                        sequenceOfElements.Insert(sequenceOfElements.Count / 2, $"-{moves}a");
                        sequenceOfElements.Insert(sequenceOfElements.Count / 2 + 1, $"-{moves}a");
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                        command = Console.ReadLine();
                        continue;
                    }

                    if(sequenceOfElements[firstIndex] == sequenceOfElements[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequenceOfElements[firstIndex]}!");
                        if(firstIndex > secondIndex)
                        {
                            sequenceOfElements.RemoveAt(firstIndex);
                            sequenceOfElements.RemoveAt(secondIndex);
                        }
                        else
                        {
                            sequenceOfElements.RemoveAt(secondIndex);
                            sequenceOfElements.RemoveAt(firstIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }    

                command = Console.ReadLine();
            }

            if(sequenceOfElements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequenceOfElements));
            }
            else
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
        }
    }
}
