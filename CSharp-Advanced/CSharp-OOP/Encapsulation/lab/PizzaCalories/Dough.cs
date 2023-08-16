using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int INITIAL_DOUGH_CALORIES = 2;
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 200;

        private readonly Dictionary<string, double> modifiersByTypeOfDough = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
        };
        private readonly Dictionary<string, double> modifiersByBakingTechnique = new Dictionary<string, double>
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 },
        };

        private string typeOfDough;
        private string bakingTechnique;
        private int grams;

        public Dough(string typeOfDough, string bakingTechnique, int grams)
        {
            TypeOfDough = typeOfDough;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        private string TypeOfDough
        { 
            get
            {
                return typeOfDough;
            }
            set
            {
                if (!modifiersByTypeOfDough.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                typeOfDough = value;
            }
        }

        private string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (!modifiersByBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                bakingTechnique = value;
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
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeight);
                }

                grams = value;
            }
        }

        public double TotalCalories
            => INITIAL_DOUGH_CALORIES
            * Grams
            * modifiersByTypeOfDough[TypeOfDough.ToLower()]
            * modifiersByBakingTechnique[BakingTechnique.ToLower()];
    }
}
