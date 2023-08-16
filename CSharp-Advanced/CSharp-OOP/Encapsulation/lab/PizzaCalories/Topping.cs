using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int INITIAL_TOPPING_CALORIES = 2;
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 50;

        private readonly Dictionary<string, double> modifiersByTopping = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 },
        };

        private string typeOfTopping;
        private int grams;

        public Topping(string typeOfTopping, int grams)
        {
            TypeOfTopping = typeOfTopping;
            Grams = grams;
        }

        private string TypeOfTopping
        {
            get
            {
                return typeOfTopping;
            }
            set
            {
                if (!modifiersByTopping.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTypeOfTopping, value));
                }

                typeOfTopping = value;
            }
        }

        private int Grams
        {
            get
            {
                return grams;
            }
            set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeight, TypeOfTopping));
                }

                grams = value;
            }
        }

        public double TotalCalories
            => INITIAL_TOPPING_CALORIES
            * Grams
            * modifiersByTopping[TypeOfTopping.ToLower()];
    }
}
