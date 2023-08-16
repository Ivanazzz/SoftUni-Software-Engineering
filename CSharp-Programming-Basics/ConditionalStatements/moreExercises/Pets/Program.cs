using System;

namespace Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int days = int.Parse(Console.ReadLine());
			int foodInKg = int.Parse(Console.ReadLine());
			double dogsFoodInKg = double.Parse(Console.ReadLine());
			double catsFoodInKg = double.Parse(Console.ReadLine());
			double turtlesFoodInGram = double.Parse(Console.ReadLine());

			double dogsFoodNeededInKg = days * dogsFoodInKg;
			double catsFoodNeededInKg = days * catsFoodInKg;
			double turtlesFoodNeededInKg = days * (turtlesFoodInGram / 1000.0);
			double totalNeededFoodInKg = dogsFoodNeededInKg + catsFoodNeededInKg + turtlesFoodNeededInKg;
			double foodDifference = foodInKg - totalNeededFoodInKg;

			if (foodDifference >= 0)
			{
				Console.WriteLine($"{Math.Floor(foodDifference)} kilos of food left.");
			}
			else
			{
				Console.WriteLine($"{Math.Ceiling(Math.Abs(foodDifference))} more kilos of food are needed.");
			}
		}
    }
}
