using System;

namespace CareOfPuppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodInKg = int.Parse(Console.ReadLine());
            int foodInGr = foodInKg * 1000;

            string command = Console.ReadLine();

            while (command != "Adopted")
            {
                int eatenFood = int.Parse(command);
                foodInGr -= eatenFood;
                command = Console.ReadLine();
            }

            if (foodInGr >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGr} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodInGr)} grams more.");
            }
        }
    }
}
