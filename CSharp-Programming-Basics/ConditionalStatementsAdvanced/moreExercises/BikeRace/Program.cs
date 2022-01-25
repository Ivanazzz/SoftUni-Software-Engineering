using System;

namespace BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniorCyclistCount = int.Parse(Console.ReadLine());
            int seniorCyclistCount = int.Parse(Console.ReadLine());
            string routeType = Console.ReadLine();

            double juniorsTax = 0;
            double seniorsTax = 0;
            double discount = 0;

            switch (routeType)
            {
                case "trail":
                    juniorsTax = juniorCyclistCount * 5.50;
                    seniorsTax = seniorCyclistCount * 7;
                    break;
                case "cross-country":
                    juniorsTax = juniorCyclistCount * 8;
                    seniorsTax = seniorCyclistCount * 9.50;

                    if (juniorCyclistCount + seniorCyclistCount >= 50)
                    {
                        discount = 0.25;
                    }
                    break;
                case "downhill":
                    juniorsTax = juniorCyclistCount * 12.25;
                    seniorsTax = seniorCyclistCount * 13.75;
                    break;
                case "road":
                    juniorsTax = juniorCyclistCount * 20;
                    seniorsTax = seniorCyclistCount * 21.50;
                    break;
            }

            double totalSum = (juniorsTax + seniorsTax) - ((juniorsTax + seniorsTax) * discount);
            double moneyLeft = totalSum - (totalSum * 0.05);

            Console.WriteLine($"{moneyLeft:f2}");
        }
    }
}
