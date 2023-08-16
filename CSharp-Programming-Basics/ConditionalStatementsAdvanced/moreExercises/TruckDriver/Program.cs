using System;

namespace TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersPerMonth = double.Parse(Console.ReadLine());

            int seasonDurationInMonths = 4;
            double salary = 0;

            if (kilometersPerMonth <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        salary = (kilometersPerMonth * 0.75) * seasonDurationInMonths;
                        break;
                    case "Summer":
                        salary = (kilometersPerMonth * 0.90) * seasonDurationInMonths;
                        break;
                    case "Winter":
                        salary = (kilometersPerMonth * 1.05) * seasonDurationInMonths;
                        break;
                }
            }
            else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        salary = (kilometersPerMonth * 0.95) * seasonDurationInMonths;
                        break;
                    case "Summer":
                        salary = (kilometersPerMonth * 1.10) * seasonDurationInMonths;
                        break;
                    case "Winter":
                        salary = (kilometersPerMonth * 1.25) * seasonDurationInMonths;
                        break;
                }
            }
            else
            {
                salary = (kilometersPerMonth * 1.45) * seasonDurationInMonths;
            }

            double moneyLeft = salary - (salary * 0.1);

            Console.WriteLine($"{moneyLeft:F2}");
        }
    }
}
