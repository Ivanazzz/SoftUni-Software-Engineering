using System;

namespace TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string package = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double price = 0;

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }

            switch (city)
            {
                case "Bansko":
                case "Borovets":
                    switch (package)
                    {
                        case "withEquipment":
                            price = 100;
                            if (VIP == "yes")
                            {
                                price -= price * 0.1;
                            }
                            break;
                        case "noEquipment":
                            price = 80;
                            if (VIP == "yes")
                            {
                                price -= price * 0.05;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                    }
                    break;
                case "Varna":
                case "Burgas":
                    switch (package)
                    {
                        case "withBreakfast":
                            price = 130;
                            if (VIP == "yes")
                            {
                                price -= price * 0.12;
                            }
                            break;
                        case "noBreakfast":
                            price = 100;
                            if (VIP == "yes")
                            {
                                price -= price * 0.07;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
            }

            if (days > 7)
            {
                days--;
            }

            double totalPrice = days * price;

            Console.WriteLine($"The price is {totalPrice:F2}lv! Have a nice time!");
        }
    }
}
