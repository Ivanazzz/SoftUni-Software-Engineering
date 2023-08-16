using System;

namespace FoodForPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            double amountOfFood = double.Parse(Console.ReadLine());

            int totalEatenFood = 0;
            int totalEatenFoodByTheDog = 0;
            int totalEatenFoodByTheCat = 0;
            double totalEatenBiscuitsInGr = 0;

            for (int i = 1; i <= day; i++)
            {
                int eatenFoodByDog = int.Parse(Console.ReadLine());
                int eatenFoodByCat = int.Parse(Console.ReadLine());
                totalEatenFood += eatenFoodByCat + eatenFoodByDog;
                totalEatenFoodByTheDog += eatenFoodByDog;
                totalEatenFoodByTheCat += eatenFoodByCat;

                if (i % 3 == 0)
                {
                    totalEatenBiscuitsInGr += (eatenFoodByCat + eatenFoodByDog) * 0.1;
                }
            }

            double totalEatenFoodPercentage = totalEatenFood / amountOfFood * 100;
            double totalEatenFoodByTheDogPercentage = totalEatenFoodByTheDog * 1.00 / totalEatenFood * 100;
            double totalEatenFoodByTheCatPercentage = totalEatenFoodByTheCat * 1.00 / totalEatenFood * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(totalEatenBiscuitsInGr)}gr.");
            Console.WriteLine($"{totalEatenFoodPercentage:F2}% of the food has been eaten.");
            Console.WriteLine($"{totalEatenFoodByTheDogPercentage:F2}% eaten from the dog.");
            Console.WriteLine($"{totalEatenFoodByTheCatPercentage:F2}% eaten from the cat.");
        }
    }
}
