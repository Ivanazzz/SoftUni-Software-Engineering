using System;

namespace SchoolCamp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsCount = int.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());

            double price = 0;
            string sportType = "";

            switch (season)
            {
                case "Winter":
                    switch (groupType)
                    {
                        case "boys":
                            price = studentsCount * nightsCount * 9.60;
                            sportType = "Judo";
                            break;
                        case "girls":
                            price = studentsCount * nightsCount * 9.60;
                            sportType = "Gymnastics";
                            break;
                        case "mixed":
                            price = studentsCount * nightsCount * 10.00;
                            sportType = "Ski";
                            break;
                    }
                    break;
                case "Spring":
                    switch (groupType)
                    {
                        case "boys":
                            price = studentsCount * nightsCount * 7.20;
                            sportType = "Tennis";
                            break;
                        case "girls":
                            price = studentsCount * nightsCount * 7.20;
                            sportType = "Athletics";
                            break;
                        case "mixed":
                            price = studentsCount * nightsCount * 9.50;
                            sportType = "Cycling";
                            break;
                    }
                    break;
                case "Summer":
                    switch (groupType)
                    {
                        case "boys":
                            price = studentsCount * nightsCount * 15.00;
                            sportType = "Football";
                            break;
                        case "girls":
                            price = studentsCount * nightsCount * 15.00;
                            sportType = "Volleyball";
                            break;
                        case "mixed":
                            price = studentsCount * nightsCount * 20.00;
                            sportType = "Swimming";
                            break;
                    }
                    break;
            }

            double discount = 0;

            if (studentsCount >= 50)
            {
                discount = 0.5;
            }
            else if (studentsCount >= 20)
            {
                discount = 0.15;
            }
            else if (studentsCount >= 10)
            {
                discount = 0.05;
            }

            double totalPrice = price - (price * discount);

            Console.WriteLine($"{sportType} {totalPrice:F2} lv.");
        }
    }
}
