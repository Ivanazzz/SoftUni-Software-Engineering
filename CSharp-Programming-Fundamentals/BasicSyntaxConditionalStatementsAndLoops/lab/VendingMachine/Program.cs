using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = 0;

            string command = Console.ReadLine();
            while(command != "Start")
            {
                double coins = double.Parse(command);
                switch (coins)
                {
                    case 0.1:
                        money += 0.1;
                        break;
                    case 0.2:
                        money += 0.2;
                        break;
                    case 0.5:
                        money += 0.5;
                        break;
                    case 1:
                        money += 1;
                        break;
                    case 2:
                        money += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        break;
                }
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while(command != "End")
            {
                bool isValid = true;
                double productPrice = 0;
                switch (command)
                {
                    case "Nuts":
                        productPrice = 2;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        isValid = false;
                        break;
                }
                if(productPrice > money && isValid)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    if(isValid)
                    {
                        Console.WriteLine($"Purchased {command.ToLower()}");
                        money -= productPrice;
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
