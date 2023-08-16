using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTicketsCount = 0;
            int standardTicketsCount = 0;
            int kidTicketsCount = 0;

            string moviesName = Console.ReadLine();

            while (moviesName != "Finish")
            {
                int totalPlaces = int.Parse(Console.ReadLine());
                int occupiedPlaces = 0;

                while (true)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    occupiedPlaces++;
                    switch (ticketType)
                    {
                        case "student":
                            studentTicketsCount++;
                            break;
                        case "standard":
                            standardTicketsCount++;
                            break;
                        case "kid":
                            kidTicketsCount++;
                            break;
                    }

                    if (occupiedPlaces == totalPlaces)
                    {
                        break;
                    }
                }

                double occupiedPlacesPercentage = occupiedPlaces * 1.00 / totalPlaces * 100;
                Console.WriteLine($"{moviesName} - {occupiedPlacesPercentage:F2}% full.");

                moviesName = Console.ReadLine();
            }

            int totalTickets = studentTicketsCount + standardTicketsCount + kidTicketsCount;
            double studentTicketsPercentage = studentTicketsCount * 1.00 / totalTickets * 100;
            double standardTicketsPercentage = standardTicketsCount * 1.00 / totalTickets * 100;
            double kidTicketsPercentage = kidTicketsCount * 1.00 / totalTickets * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTicketsPercentage:F2}% student tickets.");
            Console.WriteLine($"{standardTicketsPercentage:F2}% standard tickets.");
            Console.WriteLine($"{kidTicketsPercentage:F2}% kids tickets.");
        }
    }
}
