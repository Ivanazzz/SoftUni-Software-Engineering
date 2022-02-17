using System;

namespace Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double wantedProfit = double.Parse(Console.ReadLine());

            double pricePerCocktail = 0;
            double totalIncome = 0;

            while (true)
            {
                string cocktail = Console.ReadLine();
                if (cocktail == "Party!")
                {
                    Console.WriteLine($"We need {(wantedProfit - totalIncome):F2} leva more.");
                    break;
                }
                int numberOfCocktails = int.Parse(Console.ReadLine());
                pricePerCocktail = cocktail.Length * numberOfCocktails;
                if ((pricePerCocktail % 10) % 2 != 0)
                {
                    pricePerCocktail -= pricePerCocktail * 0.25;
                }
                totalIncome += pricePerCocktail;
                if (totalIncome >= wantedProfit)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }
            }

            Console.WriteLine($"Club income - {totalIncome:F2} leva.");
        }
    }
}
