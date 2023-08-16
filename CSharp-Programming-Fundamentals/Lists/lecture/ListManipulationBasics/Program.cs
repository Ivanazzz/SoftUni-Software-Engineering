using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<string> command = Console.ReadLine()
                .Split()
                .ToList();

            while (command[0] != "end")
            {
                switch(command[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(command[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(command[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int indexToRemoveAt = int.Parse(command[1]);
                        numbers.RemoveAt(indexToRemoveAt);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsertAt = int.Parse(command[2]);
                        numbers.Insert(indexToInsertAt, numberToInsert);
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
