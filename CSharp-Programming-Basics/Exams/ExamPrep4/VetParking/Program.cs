using System;

namespace VetParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            for (int day = 1; day <= days; day++)
            {
                double pricePerDay = 0;

                for (int hour = 1; hour <= hoursPerDay; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        pricePerDay += 2.50;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        pricePerDay += 1.25;
                    }
                    else
                    {
                        pricePerDay += 1;
                    }
                }

                totalPrice += pricePerDay;
                Console.WriteLine($"Day: {day} - {pricePerDay:F2} leva");
            }

            Console.WriteLine($"Total: {totalPrice:F2} leva");
        }
    }
}
