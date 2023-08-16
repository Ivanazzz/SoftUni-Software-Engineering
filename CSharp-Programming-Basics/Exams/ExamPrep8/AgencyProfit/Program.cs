using System;

namespace AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string airlinesName = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int kidsTickets = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double serviceFee = double.Parse(Console.ReadLine());

            double kidsTicketPrice = adultTicketPrice - (adultTicketPrice * 0.7);
            adultTicketPrice += serviceFee;
            kidsTicketPrice += serviceFee;
            double totalTicketsPrice = (adultTickets * adultTicketPrice) + (kidsTickets * kidsTicketPrice);
            double profit = totalTicketsPrice * 0.2;

            Console.WriteLine($"The profit of your agency from {airlinesName} tickets is {profit:F2} lv.");
        }
    }
}
