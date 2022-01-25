using System;

namespace Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemumsCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int tulipsCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char feastOrNormaDay = char.Parse(Console.ReadLine());

            double chrysanthemumsPrice = 0;
            double rosesPrice = 0;
            double tulipsPrice = 0;
            int flowersCount = chrysanthemumsCount + rosesCount + tulipsCount;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumsPrice = chrysanthemumsCount * 2.00;
                    rosesPrice = rosesCount * 4.10;
                    tulipsPrice = tulipsCount * 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemumsPrice = chrysanthemumsCount * 3.75;
                    rosesPrice = rosesCount * 4.50;
                    tulipsPrice = tulipsCount * 4.15;
                    break;
            }

            double flowersCurrentPrice = chrysanthemumsPrice + rosesPrice + tulipsPrice;

            if (feastOrNormaDay == 'Y')
            {
                flowersCurrentPrice += flowersCurrentPrice * 0.15;
            }

            switch (season)
            {
                case "Spring":
                    if (tulipsCount > 7)
                    {
                        flowersCurrentPrice -= flowersCurrentPrice * 0.05;
                    }
                    break;
                case "Winter":
                    if (rosesCount >= 10)
                    {
                        flowersCurrentPrice -= flowersCurrentPrice * 0.1;
                    }
                    break;
            }

            if (flowersCount > 20)
            {
                flowersCurrentPrice -= flowersCurrentPrice * 0.2;
            }

            double totalPrice = flowersCurrentPrice + 2.00;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
