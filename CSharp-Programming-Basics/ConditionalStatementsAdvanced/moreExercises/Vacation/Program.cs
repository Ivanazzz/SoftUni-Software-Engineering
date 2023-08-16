using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string placeType = "";
            double price = 0;

            if (budget <= 1000)
            {
                placeType = "Camp";

                switch (season)
                {
                    case "Summer":
                        destination = "Alaska";
                        price = budget * 0.65;
                        break;
                    case "Winter":
                        destination = "Morocco";
                        price = budget * 0.45;
                        break;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                placeType = "Hut";

                switch (season)
                {
                    case "Summer":
                        destination = "Alaska";
                        price = budget * 0.80;
                        break;
                    case "Winter":
                        destination = "Morocco";
                        price = budget * 0.60;
                        break;
                }
            }
            else
            {
                placeType = "Hotel";
                price = budget * 0.90;

                switch (season)
                {
                    case "Summer":
                        destination = "Alaska";
                        break;
                    case "Winter":
                        destination = "Morocco";
                        break;
                }
            }

            Console.WriteLine($"{destination} - {placeType} - {price:F2}");
        }
    }
}
