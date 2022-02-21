using System;

namespace ExcursionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double pricePerPerson = 0;

            if (people <= 5)
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 50;
                        break;
                    case "summer":
                        pricePerPerson = 48.50;
                        break;
                    case "autumn":
                        pricePerPerson = 60;
                        break;
                    case "winter":
                        pricePerPerson = 86;
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 48;
                        break;
                    case "summer":
                        pricePerPerson = 45;
                        break;
                    case "autumn":
                        pricePerPerson = 49.50;
                        break;
                    case "winter":
                        pricePerPerson = 85;
                        break;
                }
            }

            double totalPrice = people * pricePerPerson;

            if (season == "summer")
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (season == "winter")
            {
                totalPrice += totalPrice * 0.08;
            }

            Console.WriteLine($"{totalPrice:F2} leva.");
        }
    }
}
