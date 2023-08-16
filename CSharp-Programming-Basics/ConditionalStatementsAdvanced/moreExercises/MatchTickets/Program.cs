using System;

namespace MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int peopleCount = int.Parse(Console.ReadLine());

            double transportPrice = 0;

            if (peopleCount >= 1 && peopleCount <= 4)
            {
                transportPrice = budget * 0.75;
            }
            else if (peopleCount >= 5 && peopleCount <= 9)
            {
                transportPrice = budget * 0.6;
            }
            else if (peopleCount >= 10 && peopleCount <= 24)
            {
                transportPrice = budget * 0.5;
            }
            else if (peopleCount >= 25 && peopleCount <= 49)
            {
                transportPrice = budget * 0.4;
            }
            else
            {
                transportPrice = budget * 0.25;
            }

            budget -= transportPrice;
            double ticketsPrice = 0;

            switch (category)
            {
                case "VIP":
                    ticketsPrice = peopleCount * 499.99;
                    break;
                case "Normal":
                    ticketsPrice = peopleCount * 249.99;
                    break;
            }

            double moneyLeft = budget - ticketsPrice;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(moneyLeft):f2} leva.");
            }
        }
    }
}
