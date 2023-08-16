using System;

namespace Gymnastics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string appliance = Console.ReadLine();

            double difficulty = 0;
            double performance = 0;

            switch (country)
            {
                case "Russia":
                    switch (appliance)
                    {
                        case "ribbon":
                            difficulty = 9.100;
                            performance = 9.400;
                            break;
                        case "hoop":
                            difficulty = 9.300;
                            performance = 9.800;
                            break;
                        case "rope":
                            difficulty = 9.600;
                            performance = 9.000;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (appliance)
                    {
                        case "ribbon":
                            difficulty = 9.600;
                            performance = 9.400;
                            break;
                        case "hoop":
                            difficulty = 9.550;
                            performance = 9.750;
                            break;
                        case "rope":
                            difficulty = 9.500;
                            performance = 9.400;
                            break;
                    }
                    break;
                case "Italy":
                    switch (appliance)
                    {
                        case "ribbon":
                            difficulty = 9.200;
                            performance = 9.500;
                            break;
                        case "hoop":
                            difficulty = 9.450;
                            performance = 9.350;
                            break;
                        case "rope":
                            difficulty = 9.700;
                            performance = 9.150;
                            break;
                    }
                    break;
            }

            double totalPoints = difficulty + performance;
            double neededPoints = 20 - totalPoints;
            double neededPointsInPercentage = (neededPoints / 20) * 100;

            Console.WriteLine($"The team of {country} get {totalPoints:F3} on {appliance}.");
            Console.WriteLine($"{neededPointsInPercentage:F2}%");
        }
    }
}
