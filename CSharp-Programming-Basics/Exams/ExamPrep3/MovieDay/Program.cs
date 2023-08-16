using System;

namespace MovieDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int shootingTime = int.Parse(Console.ReadLine());
            int scenesCount = int.Parse(Console.ReadLine());
            int timePerScene = int.Parse(Console.ReadLine());

            double preparationMinutes = shootingTime * 0.15;
            int totalShootingTime = scenesCount * timePerScene;
            double neededTime = totalShootingTime + preparationMinutes;

            if (neededTime <= shootingTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(shootingTime - neededTime)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(neededTime - shootingTime)} minutes.");
            }
        }
    }
}
