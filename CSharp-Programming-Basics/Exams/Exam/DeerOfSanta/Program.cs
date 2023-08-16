using System;

namespace DeerOfSanta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int totalFoodInKg = int.Parse(Console.ReadLine());
            double firstDeerFoodInKgPerDay = double.Parse(Console.ReadLine());
            double secondDeerFoodInKgPerDay = double.Parse(Console.ReadLine());
            double thirdDeerFoodInKgPerDay = double.Parse(Console.ReadLine());

            double firstDeerTotalFood = days * firstDeerFoodInKgPerDay;
            double secondDeerTotalFood = days * secondDeerFoodInKgPerDay;
            double thirdDeerTotalFood = days * thirdDeerFoodInKgPerDay;
            double totalNeededFood = firstDeerTotalFood + secondDeerTotalFood + thirdDeerTotalFood;

            if (totalNeededFood <= totalFoodInKg)
            {
                Console.WriteLine($"{Math.Floor(totalFoodInKg - totalNeededFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalNeededFood - totalFoodInKg)} more kilos of food are needed.");
            }
        }
    }
}
