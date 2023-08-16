using System;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while(command != "Go Shopping!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string product = tokens[0];
               
                switch (product)
                {
                    case "Urgent":
                        string urgentItem = tokens[1];
                        Urgent(urgentItem, groceries);
                        break;
                    case "Unnecessary":
                        string unnecessaryItem = tokens[1];
                        Unnecessary(unnecessaryItem, groceries);
                        break;
                    case "Correct":
                        string oldItem = tokens[1];
                        string newItem = tokens[2];
                        Correct(oldItem, newItem, groceries);
                        break;
                    case "Rearrange":
                        string rearrangeItem = tokens[1];
                        Rearrange(rearrangeItem, groceries);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }

        private static void Urgent(string urgentItem, List<string> groceries)
        {
            if (!groceries.Contains(urgentItem))
            {
                groceries.Insert(0, urgentItem);
            }
        }

        private static void Unnecessary(string unnecessaryItem, List<string> groceries)
        {
            if (groceries.Contains(unnecessaryItem))
            {
                groceries.Remove(unnecessaryItem);
            }
        }

        private static void Correct(string oldItem, string newItem, List<string> groceries)
        {
            for (int item = 0; item < groceries.Count; item++)
            {
                if (groceries[item] == oldItem)
                {
                    groceries[item] = newItem;
                }
            }
        }

        private static void Rearrange(string rearrangeItem, List<string> groceries)
        {
            if (groceries.Contains(rearrangeItem))
            {
                groceries.Remove(rearrangeItem);
                groceries.Add(rearrangeItem);
            }
        }
    }
}
