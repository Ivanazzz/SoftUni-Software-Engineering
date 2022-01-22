using System;

namespace FuelTankPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string fuelType = Console.ReadLine();
			int fuelInLiters = int.Parse(Console.ReadLine());
			string clubCard = Console.ReadLine();

			double gasolinePricePerLiter = 2.22;
			double dieselPricePerLiter = 2.33;
			double gasPricePerLiter = 0.93;
			double discount = 0;
			double totalPrice = 0;

			if (clubCard == "Yes")
			{
				gasolinePricePerLiter = 2.22 - 0.18;
				dieselPricePerLiter = 2.33 - 0.12;
				gasPricePerLiter = 0.93 - 0.08;
			}

			if (fuelInLiters >= 20 && fuelInLiters <= 25)
			{
				discount = 0.08;
			}
			else if (fuelInLiters > 25)
			{
				discount = 0.1;
			}

			if (fuelType == "Gasoline")
			{
				totalPrice = fuelInLiters * gasolinePricePerLiter;
			}
			else if (fuelType == "Diesel")
			{
				totalPrice = fuelInLiters * dieselPricePerLiter;
			}
			else if (fuelType == "Gas")
			{
				totalPrice = fuelInLiters * gasPricePerLiter;
			}

			totalPrice = totalPrice - totalPrice * discount;

			Console.WriteLine($"{totalPrice:F2} lv.");
		}
    }
}
