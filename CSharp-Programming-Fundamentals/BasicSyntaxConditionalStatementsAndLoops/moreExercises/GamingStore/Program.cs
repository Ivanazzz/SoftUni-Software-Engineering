using System;

namespace GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double price = 0;
            double totalMoneySpent = 0;

            string command = Console.ReadLine();
            while(command != "Game Time")
            {
                if(command == "OutFall 4")
                {
                    price = 39.99;
                }
                else if(command == "CS: OG")
                {
                    price = 15.99;
                }
                else if(command == "Zplinter Zell")
                {
                    price = 19.99;
                }
                else if(command == "Honored 2")
                {
                    price = 59.99;
                }
                else if(command == "RoverWatch")
                {
                    price = 29.99;
                }
                else if(command == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    command = Console.ReadLine();
                    continue;
                }

                if(balance >= price)
                {
                    balance -= price;
                    totalMoneySpent += price;
                    Console.WriteLine($"Bought {command}");
                    if(balance == 0)
                    {
                        Console.WriteLine("Out of money!");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${totalMoneySpent:f2}. Remaining: ${balance:f2}");
        }
    }
}
