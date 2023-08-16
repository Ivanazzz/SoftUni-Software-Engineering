using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> caloriesByMeal = new Dictionary<string, int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 },
            };

            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int consumedMealsCount = 0;

            while (meals.Any() && caloriesPerDay.Any())
            {
                string currentMeal = meals.Dequeue();
                if (caloriesByMeal.ContainsKey(currentMeal))
                {
                    int currentCalories = caloriesPerDay.Pop();
                    currentCalories -= caloriesByMeal[currentMeal];
                    consumedMealsCount++;

                    if (currentCalories > 0)
                    {
                        caloriesPerDay.Push(currentCalories);
                    }
                    else
                    {
                        if (caloriesPerDay.Any())
                        {
                            int calories = caloriesPerDay.Pop();
                            calories -= Math.Abs(currentCalories);
                            caloriesPerDay.Push(calories);
                        }
                    }
                }
            }

            if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {consumedMealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {consumedMealsCount} meals.");
                Console.Write($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
        }
    }
}
