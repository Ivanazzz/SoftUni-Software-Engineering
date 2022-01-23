using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardsCount = int.Parse(Console.ReadLine());
            int processorCount = int.Parse(Console.ReadLine());
            int ramMemoryCount = int.Parse(Console.ReadLine());

            int videoCardsPrice = videoCardsCount * 250;
            double processorPrice = processorCount * (videoCardsPrice * 0.35);
            double ramMemoryPrice = ramMemoryCount * (videoCardsPrice * 0.1);
            double totalPrice = videoCardsPrice + processorPrice + ramMemoryPrice;

            if (videoCardsCount > processorCount)
            {
                totalPrice -= totalPrice * 0.15;
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have {(budget - totalPrice):F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalPrice - budget):F2} leva more!");
            }
        }
    }
}
