using System;

namespace FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int totalFansCount = int.Parse(Console.ReadLine());

            int fansInSectorA = 0;
            int fansInSectorB = 0;
            int fansInSectorV = 0;
            int fansInSectorG = 0;

            for (int fan = 1; fan <= totalFansCount; fan++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A':
                        fansInSectorA++;
                        break;
                    case 'B':
                        fansInSectorB++;
                        break;
                    case 'V':
                        fansInSectorV++;
                        break;
                    case 'G':
                        fansInSectorG++;
                        break;
                }
            }

            double fansPercentageInSecorA = fansInSectorA * 1.00 / totalFansCount * 100;
            double fansPercentageInSecorB = fansInSectorB * 1.00 / totalFansCount * 100;
            double fansPercentageInSecorV = fansInSectorV * 1.00 / totalFansCount * 100;
            double fansPercentageInSecorG = fansInSectorG * 1.00 / totalFansCount * 100;
            double totalFansPercentage = totalFansCount * 1.00 / stadiumCapacity * 100;

            Console.WriteLine($"{fansPercentageInSecorA:F2}%");
            Console.WriteLine($"{fansPercentageInSecorB:F2}%");
            Console.WriteLine($"{fansPercentageInSecorV:F2}%");
            Console.WriteLine($"{fansPercentageInSecorG:F2}%");
            Console.WriteLine($"{totalFansPercentage:F2}%");
        }
    }
}
