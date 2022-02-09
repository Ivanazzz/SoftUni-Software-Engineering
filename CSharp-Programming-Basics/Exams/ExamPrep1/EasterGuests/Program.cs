using System;

namespace EasterGuests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double sweetBreadsCount = Math.Ceiling(guestsCount * 1.00 / 3);
            int eggsCount = guestsCount * 2;

            double sweetBreadsPrice = sweetBreadsCount * 4;
            double eggsPrice = eggsCount * 0.45;
            double totalPrice = sweetBreadsPrice + eggsPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Lyubo bought {sweetBreadsCount} Easter bread and {eggsCount} eggs.");
                Console.WriteLine($"He has {(budget - totalPrice):F2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {(totalPrice - budget):F2} lv. more.");
            }
        }
    }
}
