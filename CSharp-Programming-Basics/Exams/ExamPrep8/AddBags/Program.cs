using System;

namespace AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double luggagePriceAbove20Kg = double.Parse(Console.ReadLine());
            double luggageInKg = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int luggageCount = int.Parse(Console.ReadLine());

            double luggageCost = 0;

            if (luggageInKg < 10)
            {
                luggageCost = luggagePriceAbove20Kg * 0.2;
            }
            else if (luggageInKg <= 20)
            {
                luggageCost = luggagePriceAbove20Kg * 0.5;
            }
            else
            {
                luggageCost = luggagePriceAbove20Kg;
            }

            if (days > 30)
            {
                luggageCost += luggageCost * 0.1;
            }
            else if (days >= 7)
            {
                luggageCost += luggageCost * 0.15;
            }
            else
            {
                luggageCost += luggageCost * 0.4;
            }

            double totalPrice = luggageCount * luggageCost;
            Console.WriteLine($"The total price of bags is: {totalPrice:F2} lv. ");
        }
    }
}
