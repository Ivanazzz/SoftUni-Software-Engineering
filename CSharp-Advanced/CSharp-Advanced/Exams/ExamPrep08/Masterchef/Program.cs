using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dish> dishes = new Dictionary<int, Dish>()
            {
                { 300,  new Dish("Chocolate cake", 300, 0) },
                { 150,  new Dish("Dipping sauce", 150, 0) },
                { 250,  new Dish("Green salad", 250, 0) },
                { 400,  new Dish("Lobster", 400, 0) },
            };

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> freshnessLevelOfTheIngredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (ingredients.Any() && freshnessLevelOfTheIngredients.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();

                    continue;
                }

                int currentValue = ingredients.Peek() * freshnessLevelOfTheIngredients.Peek();

                if (dishes.ContainsKey(currentValue))
                {
                    dishes[currentValue].Count++;
                    ingredients.Dequeue();
                    freshnessLevelOfTheIngredients.Pop();
                }
                else
                {
                    freshnessLevelOfTheIngredients.Pop();
                    int temp = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(temp);
                }
            }

            bool isValid = true;
            foreach (Dish dish in dishes.Values)
            {
                if (dish.Count == 0)
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (Dish dish in dishes.Values)
            {
                if (dish.Count > 0)
                {
                    Console.WriteLine($" # {dish.Name} --> {dish.Count}");
                }
            }
        }
    }

    public class Dish
    {
        public Dish(string name, int value, int count)
        {
            Name = name;
            Value = value;
            Count = count;
        }

        public string Name { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}
