using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[] command = Console.ReadLine().Split(" - ");
            while(command[0] != "Craft!")
            {
                string action = command[0];
                switch (action)
                {
                    case "Collect":
                        string itemToCollect = command[1];
                        CollectItem(itemToCollect, journal);
                        break;
                    case "Drop":
                        string itemToDrop = command[1];
                        DropItem(itemToDrop, journal);
                        break;
                    case "Combine Items":
                        string[] tokens = command[1].Split(":");
                        string oldItem = tokens[0];
                        string newItem = tokens[1];
                        CombineItems(oldItem, newItem, journal);
                        break;
                    case "Renew":
                        string itemToRenew = command[1];
                        RenewItem(itemToRenew, journal);
                        break;
                }

                command = Console.ReadLine().Split(" - ");
            }

            Console.WriteLine(string.Join(", ", journal));
        }

        private static void CollectItem(string itemToCollect, List<string> journal)
        {
            if(!journal.Contains(itemToCollect))
            {
                journal.Add(itemToCollect);
            }
        }

        private static void DropItem(string itemToDrop, List<string> journal)
        {
            if (journal.Contains(itemToDrop))
            {
                journal.Remove(itemToDrop);
            }
        }

        private static void CombineItems(string oldItem, string newItem, List<string> journal)
        {
            if (journal.Contains(oldItem))
            {
                int indexForNewItem = journal.IndexOf(oldItem) + 1;
                journal.Insert(indexForNewItem, newItem);
            }
        }

        private static void RenewItem(string itemToRenew, List<string> journal)
        {
            if (journal.Contains(itemToRenew))
            {
                journal.Remove(itemToRenew);
                journal.Add(itemToRenew);
            }
        }
    }
}
