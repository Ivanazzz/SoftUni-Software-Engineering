using System;

namespace CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string classType = "";
            string carType = "";
            double price = 0;

            if (budget <= 100)
            {
                classType = "Economy class";

                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        price = budget * 0.35;
                        break;
                    case "Winter":
                        carType = "Jeep";
                        price = budget * 0.65;
                        break;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                classType = "Compact class";

                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        price = budget * 0.45;
                        break;
                    case "Winter":
                        carType = "Jeep";
                        price = budget * 0.80;
                        break;
                }
            }
            else
            {
                classType = "Luxury class";
                carType = "Jeep";
                price = budget * 0.90;
            }

            Console.WriteLine($"{classType}");
            Console.WriteLine($"{carType} - {price:F2}");
        }
    }
}
