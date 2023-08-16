using System;

namespace Excursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportCards = int.Parse(Console.ReadLine());
            int museumTickets = int.Parse(Console.ReadLine());

            int nightsPrice = nights * 20;
            double transportCardsPrice = transportCards * 1.60;
            int museumTicketsPrice = museumTickets * 6;
            double totalPricePerPerson = nightsPrice + transportCardsPrice + museumTicketsPrice;
            double totalPrice = people * totalPricePerPerson;
            totalPrice += totalPrice * 0.25;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
