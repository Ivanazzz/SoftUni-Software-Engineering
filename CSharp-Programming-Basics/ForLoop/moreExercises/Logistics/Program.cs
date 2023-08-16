using System;

namespace Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLoads = int.Parse(Console.ReadLine());
            int totalTons = 0;
            int tonsInMinibus = 0;
            int tonsInTruck = 0;
            int tonsInTrain = 0;

            for (int i = 1; i <= numberOfLoads; i++)
            {
                int cargoTonnage = int.Parse(Console.ReadLine());
                if (cargoTonnage <= 3)
                {
                    tonsInMinibus += cargoTonnage;
                }
                else if (cargoTonnage <= 11)
                {
                    tonsInTruck += cargoTonnage;
                }
                else
                {
                    tonsInTrain += cargoTonnage;
                }

                totalTons += cargoTonnage;
            }

            double averagePricePerTon = ((tonsInMinibus * 200) + (tonsInTruck * 175) + (tonsInTrain * 120)) * 1.00 / totalTons;
            double minibusPricePercent = tonsInMinibus * 1.00 / totalTons * 100;
            double truckPricePercent = tonsInTruck * 1.00 / totalTons * 100;
            double trainPricePercent = tonsInTrain * 1.00 / totalTons * 100;

            Console.WriteLine($"{averagePricePerTon:F2}");
            Console.WriteLine($"{minibusPricePercent:F2}%");
            Console.WriteLine($"{truckPricePercent:F2}%");
            Console.WriteLine($"{trainPricePercent:F2}%");
        }
    }
}
