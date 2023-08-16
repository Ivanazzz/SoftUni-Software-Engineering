using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MIN_NAME_LENGTH = 1;
        private const int MAX_NAME_LENGTH = 15;
        private const int MAX_NUMBER_OF_TOPPINGS = 10;

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < MIN_NAME_LENGTH || 
                    value.Length > MAX_NAME_LENGTH)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaName);
                }

                name = value;
            }
        }

        private Dough Dough { get; set; }

        public int ToppingsCount
            => toppings.Count;

        public double TotalCalories
            => toppings.Sum(t => t.TotalCalories) + Dough.TotalCalories;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= MAX_NUMBER_OF_TOPPINGS)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfToppings);
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
