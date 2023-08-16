using System;

namespace Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string campOrHotel = "";
            double percent = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        campOrHotel = "Camp";
                        percent = 0.3;
                        break;
                    case "winter":
                        campOrHotel = "Hotel";
                        percent = 0.7;
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        campOrHotel = "Camp";
                        percent = 0.4;
                        break;
                    case "winter":
                        campOrHotel = "Hotel";
                        percent = 0.8;
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                campOrHotel = "Hotel";
                percent = 0.9;
            }

            double totalPrice = budget * percent;
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{campOrHotel} - {totalPrice:f2}");
        }
    }
}
