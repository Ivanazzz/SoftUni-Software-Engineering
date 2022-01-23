using System;

namespace HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double apartmentPricePerNight = 0;
            double studioPricePerNight = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPricePerNight = 50;
                    apartmentPricePerNight = 65;
                    
                    if (nights > 14)
                    {
                        studioPricePerNight = studioPricePerNight - (studioPricePerNight * 0.3);
                        apartmentPricePerNight = apartmentPricePerNight - (apartmentPricePerNight * 0.1);
                    }
                    else if (nights > 7)
                    {
                        studioPricePerNight = studioPricePerNight - (studioPricePerNight * 0.05);
                    }
                    break;
                case "June":
                case "September":
                    studioPricePerNight = 75.20;
                    apartmentPricePerNight = 68.70;
                    
                    if (nights > 14)
                    {
                        studioPricePerNight = studioPricePerNight - (studioPricePerNight * 0.2);
                        apartmentPricePerNight = apartmentPricePerNight - (apartmentPricePerNight * 0.1);
                    }
                    break;
                case "July":
                case "August":
                    studioPricePerNight = 76;
                    apartmentPricePerNight = 77;
                    if (nights > 14)
                    {
                        apartmentPricePerNight = apartmentPricePerNight - (apartmentPricePerNight * 0.1);
                    }
                    break;
            }
            double apartmentPrice = nights * apartmentPricePerNight;
            double studioPrice = nights * studioPricePerNight;
            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
