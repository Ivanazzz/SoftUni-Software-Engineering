using System;

namespace GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int movesCount = int.Parse(Console.ReadLine());

            int numsCountFrom0To9 = 0;
            int numsCountFrom10To19 = 0;
            int numsCountFrom20To29 = 0;
            int numsCountFrom30To39 = 0;
            int numsCountFrom40To50 = 0;
            int invalidNumsCount = 0;
            double points = 0;

            for (int move = 1; move <= movesCount; move++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 50)
                {
                    invalidNumsCount++;
                    points = points * 1.00 / 2;
                }
                else if (number < 10)
                {
                    numsCountFrom0To9++;
                    points += number * 0.2;
                }
                else if (number < 20)
                {
                    numsCountFrom10To19++;
                    points += number * 0.3;
                }
                else if (number < 30)
                {
                    numsCountFrom20To29++;
                    points += number * 0.4;
                }
                else if (number < 40)
                {
                    numsCountFrom30To39++;
                    points += 50;
                }
                else
                {
                    numsCountFrom40To50++;
                    points += 100;
                }
            }

            double numsPercentageFrom0To9 = numsCountFrom0To9 * 1.00 / movesCount * 100;
            double numsPercentageFrom10To19 = numsCountFrom10To19 * 1.00 / movesCount * 100;
            double numsPercentageFrom20To29 = numsCountFrom20To29 * 1.00 / movesCount * 100;
            double numsPercentageFrom30To39 = numsCountFrom30To39 * 1.00 / movesCount * 100;
            double numsPercentageFrom40To50 = numsCountFrom40To50 * 1.00 / movesCount * 100;
            double invalidNumsPercentage = invalidNumsCount * 1.00 / movesCount * 100;

            Console.WriteLine($"{points:F2}");
            Console.WriteLine($"From 0 to 9: {numsPercentageFrom0To9:F2}%");
            Console.WriteLine($"From 10 to 19: {numsPercentageFrom10To19:F2}%");
            Console.WriteLine($"From 20 to 29: {numsPercentageFrom20To29:F2}%");
            Console.WriteLine($"From 30 to 39: {numsPercentageFrom30To39:F2}%");
            Console.WriteLine($"From 40 to 50: {numsPercentageFrom40To50:F2}%");
            Console.WriteLine($"Invalid numbers: {invalidNumsPercentage:F2}%");
        }
    }
}
