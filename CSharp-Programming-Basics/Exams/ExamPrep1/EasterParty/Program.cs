using System;

namespace EasterParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            double couvertPricePerPerson = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (guestsCount >= 10 && guestsCount <= 15)
            {
                couvertPricePerPerson -= couvertPricePerPerson * 0.15;
            }
            else if (guestsCount >= 16 && guestsCount <= 20)
            {
                couvertPricePerPerson -= couvertPricePerPerson * 0.2;
            }
            else if (guestsCount > 20)
            {
                couvertPricePerPerson -= couvertPricePerPerson * 0.25;
            }

            double cakesPrice = budget * 0.1;
            double totalPrice = (guestsCount * couvertPricePerPerson) + cakesPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"It is party time! {(budget - totalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {(totalPrice - budget):F2} leva needed.");
            }
        }
    }
}
