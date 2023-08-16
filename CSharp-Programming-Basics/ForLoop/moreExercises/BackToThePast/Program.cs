using System;

namespace BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inheritedMoney = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            int boysAge = 18;

            for (int y = 1800; y <= year; y++)
            {
                if (y % 2 == 0)
                {
                    inheritedMoney -= 12000;
                }
                else
                {
                    inheritedMoney -= (12000 + (50 * boysAge));
                }
                boysAge++;
            }

            if (inheritedMoney >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheritedMoney:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(inheritedMoney):F2} dollars to survive.");
            }

        }
    }
}
