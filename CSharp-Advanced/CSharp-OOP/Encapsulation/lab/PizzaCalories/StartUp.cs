using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();
                string[] doughTokens = Console.ReadLine().Split();

                string pizzaName = pizzaTokens[1];
                string typeOfDough = doughTokens[1];
                string doughBakingTechnique = doughTokens[2];
                int doughGrams = int.Parse(doughTokens[3]);

                Dough dough = new Dough(typeOfDough, doughBakingTechnique, doughGrams);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = command.Split();

                    string typeOfTopping = toppingTokens[1];
                    int toppingGrams = int.Parse(toppingTokens[2]);

                    Topping topping = new Topping(typeOfTopping, toppingGrams);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
