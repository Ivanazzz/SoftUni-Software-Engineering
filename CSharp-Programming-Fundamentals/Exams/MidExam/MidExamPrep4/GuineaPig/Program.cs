using System;

namespace GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double foodInKg = double.Parse(Console.ReadLine());
            //double hayInKg = double.Parse(Console.ReadLine());
            //double coverInKg = double.Parse(Console.ReadLine());
            //double pigsWeight = double.Parse(Console.ReadLine());
            //
            //for (int day = 1; day <= 30; day++)
            //{
            //    foodInKg -= 0.3;
            //    if (day % 2 == 0)
            //    {
            //        hayInKg -= foodInKg * 0.05;
            //    }
            //    else if (day % 3 == 0)
            //    {
            //        coverInKg -= pigsWeight / 3;
            //    }   
            //
            //    if (foodInKg < 0 || hayInKg < 0 || coverInKg < 0)
            //    {
            //        Console.WriteLine("Merry must go to the pet store!");
            //        Environment.Exit(0);
            //    }
            //}
            //
            //Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodInKg:f2}, Hay: {hayInKg:f2}, Cover: {coverInKg:f2}.");

            double foodInKg = double.Parse(Console.ReadLine());
            double hayInKg = double.Parse(Console.ReadLine());
            double coverInKg = double.Parse(Console.ReadLine());
            double pigsWeightInKg = double.Parse(Console.ReadLine());

            double foodInGrams = foodInKg * 1000;
            double hayInGrams = hayInKg * 1000;
            double coverInGrams = coverInKg * 1000;
            double pigsWeightInGrams = pigsWeightInKg * 1000;

            int foodPerDay = 300;
            for (int day = 1; day <= 30; day++)
            {
                foodInGrams -= foodPerDay;
                if (day % 2 == 0)
                {
                    double hayPerDay = foodInGrams * 0.05;
                    hayInGrams -= hayPerDay;
                }
                if (day % 3 == 0)
                {
                    double coverPerDay = pigsWeightInGrams / 3;
                    coverInGrams -= coverPerDay;
                }

                if (foodInGrams <= 0 || hayInGrams <= 0 || coverInGrams <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    Environment.Exit(0);
                }
            }

            double foodLeft = foodInGrams / 1000;
            double hayLeft = hayInGrams / 1000;
            double coverLeft = coverInGrams / 1000;

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodLeft:f2}, Hay: {hayLeft:f2}, Cover: {coverLeft:f2}.");
        }
    }
}
