using System;

namespace FuelTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string fuelType = Console.ReadLine();
			int fuelInLiters = int.Parse(Console.ReadLine());
			bool isValid = true;

			if (fuelType != "Diesel" && fuelType != "Gasoline" && fuelType != "Gas")
			{
				isValid = false;
				Console.WriteLine("Invalid fuel!");
			}

			if (fuelInLiters >= 25 && isValid)
			{
				Console.WriteLine($"You have enough {fuelType.ToLower()}.");
			}
			else if (fuelInLiters < 25 && isValid)
			{
				Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
			}
		}
    }
}
