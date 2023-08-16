using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Dictionary<string, Ingredient> Ingredients;

        public int CurrentAlcoholLevel { get => Ingredients.Values.Sum(x => x.Alcohol); }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) && this.Capacity > 0 && ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
                this.Capacity--;
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                Ingredients.Remove(name);
                this.Capacity++;

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            if (!Ingredients.Any())
            {
                return null;
            }

            Dictionary<string, Ingredient> sortedIngredients = Ingredients
                .OrderByDescending(x => x.Value.Alcohol)
                .ToDictionary(x => x.Key, x => x.Value);

            return sortedIngredients.FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (Ingredient ingredient in Ingredients.Values)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
