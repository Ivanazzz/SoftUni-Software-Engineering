using System;

namespace CatWalking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesWalkPerDay = int.Parse(Console.ReadLine());
            int walksPerDay = int.Parse(Console.ReadLine());
            int consumedCaloriesPerDay = int.Parse(Console.ReadLine());

            int totalMinutesWalk = minutesWalkPerDay * walksPerDay;
            int totalBurnedCalories = totalMinutesWalk * 5;

            if (totalBurnedCalories >= consumedCaloriesPerDay * 0.5)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalBurnedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalBurnedCalories}.");
            }
        }
    }
}
