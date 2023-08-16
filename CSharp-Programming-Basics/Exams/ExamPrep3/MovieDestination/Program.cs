using System;

namespace MovieDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            int price = 0;

            switch (destination)
            {
                case "Dubai":
                    switch (season)
                    {
                        case "Winter":
                            price = 45000;
                            break;
                        case "Summer":
                            price = 40000;
                            break;
                    }    
                    break;
                case "Sofia":
                    switch (season)
                    {
                        case "Winter":
                            price = 17000;
                            break;
                        case "Summer":
                            price = 12500;
                            break;
                    }
                    break;
                case "London":
                    switch (season)
                    {
                        case "Winter":
                            price = 24000;
                            break;
                        case "Summer":
                            price = 20250;
                            break;
                    }
                    break;
            }

            double totalPrice = days * price;

            if (destination == "Dubai")
            {
                totalPrice -= totalPrice * 0.3;
            }
            else if (destination == "Sofia")
            {
                totalPrice += totalPrice * 0.25;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {(budget - totalPrice):F2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {(totalPrice - budget):F2} leva more!");
            }
        }
    }
}
