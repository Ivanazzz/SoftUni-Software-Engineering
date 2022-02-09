using System;

namespace EasterTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            int price = 0;

            switch (destination)
            {
                case "France":
                    switch (date)
                    {
                        case "21-23":
                            price = 30;
                            break;
                        case "24-27":
                            price = 35;
                            break;
                        case "28-31":
                            price = 40;
                            break;
                    }
                    break;
                case "Italy":
                    switch (date)
                    {
                        case "21-23":
                            price = 28;
                            break;
                        case "24-27":
                            price = 32;
                            break;
                        case "28-31":
                            price = 39;
                            break;
                    }
                    break;
                case "Germany":
                    switch (date)
                    {
                        case "21-23":
                            price = 32;
                            break;
                        case "24-27":
                            price = 37;
                            break;
                        case "28-31":
                            price = 43;
                            break;
                    }
                    break;
            }

            int totalPrice = nights * price;
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:F2} leva.");
        }
    }
}
