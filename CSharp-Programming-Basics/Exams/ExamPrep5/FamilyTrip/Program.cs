using System;

namespace FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int additionalCostsPercentage = int.Parse(Console.ReadLine());

            if (nights > 7)
            {
                pricePerNight -= pricePerNight * 0.05;
            }

            double totalNightsPrice = nights * pricePerNight;
            double additionalCosts = budget * additionalCostsPercentage / 100;
            double totalPrice = totalNightsPrice + additionalCosts;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Ivanovi will be left with {(budget - totalPrice):F2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{(totalPrice - budget):F2} leva needed.");
            }
        }
    }
}
