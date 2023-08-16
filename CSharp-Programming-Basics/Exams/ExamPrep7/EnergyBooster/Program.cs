using System;

namespace EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setsSize = Console.ReadLine();
            int setsCount = int.Parse(Console.ReadLine());

            double pricePerSet = 0;

            switch (fruit)
            {
                case "Watermelon":
                    switch (setsSize)
                    {
                        case "small":
                            pricePerSet = 2 * 56;
                            break;
                        case "big":
                            pricePerSet = 5 * 28.70;
                            break;
                    }
                    break;
                case "Mango":
                    switch (setsSize)
                    {
                        case "small":
                            pricePerSet = 2 * 36.66;
                            break;
                        case "big":
                            pricePerSet = 5 * 19.60;
                            break;
                    }
                    break;
                case "Pineapple":
                    switch (setsSize)
                    {
                        case "small":
                            pricePerSet = 2 * 42.10;
                            break;
                        case "big":
                            pricePerSet = 5 * 24.80;
                            break;
                    }
                    break;
                case "Raspberry":
                    switch (setsSize)
                    {
                        case "small":
                            pricePerSet = 2 * 20;
                            break;
                        case "big":
                            pricePerSet = 5 * 15.20;
                            break;
                    }
                    break;
            }

            double totalSetsPrice = setsCount * pricePerSet;

            if (totalSetsPrice >= 400 && totalSetsPrice <= 1000)
            {
                totalSetsPrice -= totalSetsPrice * 0.15;
            }
            else if (totalSetsPrice > 1000)
            {
                totalSetsPrice -= totalSetsPrice * 0.5;
            }

            Console.WriteLine($"{totalSetsPrice:F2} lv.");
        }
    }
}
