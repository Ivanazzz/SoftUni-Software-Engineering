using System;
using System.Collections.Generic;

namespace AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceByQuantity = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (!resourceByQuantity.ContainsKey(resource))
                {
                    resourceByQuantity.Add(resource, quantity);
                }
                else
                {
                    resourceByQuantity[resource] += quantity;
                }
            }

            foreach (var item in resourceByQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
