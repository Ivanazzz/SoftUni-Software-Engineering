using System;

namespace CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int drinksCount = int.Parse(Console.ReadLine());

            double price = 0;

            switch (drink)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without":
                            price = 0.90;
                            break;
                        case "Normal":
                            price = 1.00;
                            break;
                        case "Extra":
                            price = 1.20;
                            break;
                    }    
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without":
                            price = 1.00;
                            break;
                        case "Normal":
                            price = 1.20;
                            break;
                        case "Extra":
                            price = 1.60;
                            break;
                    }
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without":
                            price = 0.50;
                            break;
                        case "Normal":
                            price = 0.60;
                            break;
                        case "Extra":
                            price = 0.70;
                            break;
                    }
                    break;
            }

            double totalPrice = drinksCount * price;

            if (sugar == "Without")
            {
                totalPrice -= totalPrice * 0.35;
            }
            if (drink == "Espresso" && drinksCount >= 5)
            {
                totalPrice -= totalPrice * 0.25;
            }
            if (totalPrice > 15)
            {
                totalPrice -= totalPrice * 0.2;
            }

            Console.WriteLine($"You bought {drinksCount} cups of {drink} for {totalPrice:F2} lv.");
        }
    }
}
