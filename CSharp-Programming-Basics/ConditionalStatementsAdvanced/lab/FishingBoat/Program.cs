using System;

namespace FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermanCount = int.Parse(Console.ReadLine());
            int boatRent = 0;
            double discount = 0;
            double extraDiscount = 0;

            switch (season)
            {
                case "Spring":
                    boatRent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    boatRent = 4200;
                    break;
                case "Winter":
                    boatRent = 2600;
                    break;
            }

            if (fishermanCount <= 6)
            {
                discount = 0.1;
            }
            else if (fishermanCount >= 7 && fishermanCount <= 11)
            {
                discount = 0.15;
            }
            else if (fishermanCount >= 12)
            {
                discount = 0.25;
            }

            double currentSum = boatRent - (boatRent * discount);

            if (fishermanCount % 2 == 0)
            {
                switch (season)
                {
                    case "Spring":
                    case "Summer":
                    case "Winter":
                        extraDiscount = 0.05;
                        break;
                }
            }

            double totalSum = currentSum - (currentSum * extraDiscount);
            double totalPrice = budget - totalSum;

            if (totalPrice < 0)
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(totalPrice):f2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {totalPrice:f2} leva left.");
            }
        }
    }
}
