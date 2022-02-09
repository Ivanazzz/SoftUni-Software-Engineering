using System;

namespace EasterBake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sweetBreadsCount = int.Parse(Console.ReadLine());

            int maxUsedSugarInGr = 0;
            int maxUsedFlourInGr = 0;
            int totalNeededSugarInGr = 0;
            int totalNeededFlourInGr = 0;

            for (int sweetBread = 1; sweetBread <= sweetBreadsCount; sweetBread++)
            {
                int sugarInGr = int.Parse(Console.ReadLine());
                int flourInGr = int.Parse(Console.ReadLine());

                totalNeededSugarInGr += sugarInGr;
                totalNeededFlourInGr += flourInGr;

                if (sugarInGr > maxUsedSugarInGr)
                {
                    maxUsedSugarInGr = sugarInGr;
                }
                if (flourInGr > maxUsedFlourInGr)
                {
                    maxUsedFlourInGr = flourInGr;
                }
            }

            double usedSugarPackagesCount = Math.Ceiling(totalNeededSugarInGr * 1.00 / 950);
            double usedFlourPackagesCount = Math.Ceiling(totalNeededFlourInGr * 1.00 / 750);

            Console.WriteLine($"Sugar: {usedSugarPackagesCount}");
            Console.WriteLine($"Flour: {usedFlourPackagesCount}");
            Console.WriteLine($"Max used flour is {maxUsedFlourInGr} grams, max used sugar is {maxUsedSugarInGr} grams.");
        }
    }
}
