using System;

namespace WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stageOfTheChampionship = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            char photoWithTheTrophy = char.Parse(Console.ReadLine());

            double price = 0;

            switch (stageOfTheChampionship)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            price = 55.50;
                            break;
                        case "Premium":
                            price = 105.20;
                            break;
                        case "VIP":
                            price = 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            price = 75.88;
                            break;
                        case "Premium":
                            price = 125.22;
                            break;
                        case "VIP":
                            price = 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            price = 110.10;
                            break;
                        case "Premium":
                            price = 160.66;
                            break;
                        case "VIP":
                            price = 400;
                            break;
                    }
                    break;
            }

            double totalTicketsPrice = ticketsCount * price;
            int photoWithTheTrophyPrice = 0;

            if (totalTicketsPrice > 4000)
            {
                totalTicketsPrice -= totalTicketsPrice * 0.25;
            }
            else if (totalTicketsPrice > 2500)
            {
                totalTicketsPrice -= totalTicketsPrice * 0.1;
                if (photoWithTheTrophy == 'Y')
                {
                    photoWithTheTrophyPrice = ticketsCount * 40;
                }
            }
            else
            {
                if (photoWithTheTrophy == 'Y')
                {
                    photoWithTheTrophyPrice = ticketsCount * 40;
                }
            }

            double totalPrice = totalTicketsPrice + photoWithTheTrophyPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
