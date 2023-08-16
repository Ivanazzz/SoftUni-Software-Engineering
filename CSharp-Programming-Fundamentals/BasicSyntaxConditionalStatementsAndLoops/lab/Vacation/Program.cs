using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfThePeople = int.Parse(Console.ReadLine());
            string typeOfTheGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();

            double price = 0;

            switch (dayOfTheWeek)
            {
                case "Friday":
                    switch (typeOfTheGroup)
                    {
                        case "Students":
                            price = 8.45;
                            break;
                        case "Business":
                            price = 10.90;
                            break;
                        case "Regular":
                            price = 15.00;
                            break;
                    }
                    break;
                case "Saturday":
                    switch (typeOfTheGroup)
                    {
                        case "Students":
                            price = 9.80;
                            break;
                        case "Business":
                            price = 15.60;
                            break;
                        case "Regular":
                            price = 20.00;
                            break;
                    }
                    break;
                case "Sunday":
                    switch (typeOfTheGroup)
                    {
                        case "Students":
                            price = 10.46;
                            break;
                        case "Business":
                            price = 16.00;
                            break;
                        case "Regular":
                            price = 22.50;
                            break;
                    }
                    break;
            }

            double totalPrice = countOfThePeople * price;

            if(typeOfTheGroup == "Students" && countOfThePeople >= 30)
            {
                totalPrice -= totalPrice * 0.15;
            }
            if(typeOfTheGroup == "Business" && countOfThePeople >= 100)
            {
                totalPrice -= (10 * price);
            }
            if(typeOfTheGroup == "Regular" && (countOfThePeople >= 10 && countOfThePeople <= 20))
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
