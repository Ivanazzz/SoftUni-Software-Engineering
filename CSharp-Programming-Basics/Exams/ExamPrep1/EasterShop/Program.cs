using System;

namespace EasterShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsQuantity = int.Parse(Console.ReadLine());

            int soldEggs = 0;
            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "Close")
            {
                int currentEggs = int.Parse(Console.ReadLine());
                if (command == "Buy")
                {
                    if (eggsQuantity < currentEggs)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsQuantity}.");
                        isValid = false;
                        break;
                    }
                    else
                    {
                        eggsQuantity -= currentEggs;
                        soldEggs += currentEggs;
                    }
                }
                else if (command == "Fill")
                {
                    eggsQuantity += currentEggs;
                }
                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{soldEggs} eggs sold.");
            }
        }
    }
}
