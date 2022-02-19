using System;

namespace FitnessCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;

            switch (gender)
            {
                case 'm':
                    switch (sport)
                    {
                        case "Gym":
                            price = 42;
                            break;
                        case "Boxing":
                            price = 41;
                            break;
                        case "Yoga":
                            price = 45;
                            break;
                        case "Zumba":
                            price = 34;
                            break;
                        case "Dances":
                            price = 51;
                            break;
                        case "Pilates":
                            price = 39;
                            break;
                    }
                    break;
                case 'f':
                    switch (sport)
                    {
                        case "Gym":
                            price = 35;
                            break;
                        case "Boxing":
                            price = 37;
                            break;
                        case "Yoga":
                            price = 42;
                            break;
                        case "Zumba":
                            price = 31;
                            break;
                        case "Dances":
                            price = 53;
                            break;
                        case "Pilates":
                            price = 37;
                            break;
                    }
                    break;
            }

            if (age <= 19)
            {
                price -= price * 0.2;
            }

            if (budget >= price)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${(price - budget):F2} more.");
            }
        }
    }
}
