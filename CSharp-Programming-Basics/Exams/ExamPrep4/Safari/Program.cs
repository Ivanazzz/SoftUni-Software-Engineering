using System;

namespace Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litersOfFuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double fuelsPrice = litersOfFuel * 2.10;
            double totalPrice = fuelsPrice + 100;

            switch (day)
            {
                case "Saturday":
                    totalPrice -= totalPrice * 0.1;
                    break;
                case "Sunday":
                    totalPrice -= totalPrice * 0.2;
                    break;
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Safari time! Money left: {(budget - totalPrice):F2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {(totalPrice - budget):F2} lv.");
            }
        }
    }
}
