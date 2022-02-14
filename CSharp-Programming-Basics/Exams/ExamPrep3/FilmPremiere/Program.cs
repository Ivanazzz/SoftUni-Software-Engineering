using System;

namespace FilmPremiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string package = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            int price = 0;

            switch (movie)
            {
                case "John Wick":
                    switch (package)
                    {
                        case "Drink":
                            price = 12;
                            break;
                        case "Popcorn":
                            price = 15;
                            break;
                        case "Menu":
                            price = 19;
                            break;
                    }
                    break;
                case "Star Wars":
                    switch (package)
                    {
                        case "Drink":
                            price = 18;
                            break;
                        case "Popcorn":
                            price = 25;
                            break;
                        case "Menu":
                            price = 30;
                            break;
                    }
                    break;
                case "Jumanji":
                    switch (package)
                    {
                        case "Drink":
                            price = 9;
                            break;
                        case "Popcorn":
                            price = 11;
                            break;
                        case "Menu":
                            price = 14;
                            break;
                    }
                    break;
            }

            double totalPrice = tickets * price;

            if (movie == "Star Wars" && tickets >= 4)
            {
                totalPrice -= totalPrice * 0.3;
            }
            else if (movie == "Jumanji" && tickets == 2)
            {
                totalPrice -= totalPrice * 0.15;
            }

            Console.WriteLine($"Your bill is {totalPrice:F2} leva.");
        }
    }
}
