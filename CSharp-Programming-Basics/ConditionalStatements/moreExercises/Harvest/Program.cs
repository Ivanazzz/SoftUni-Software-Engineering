using System;

namespace Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vineyardSqrtMeter = int.Parse(Console.ReadLine());
            double grapesPerSqrtMeter = double.Parse(Console.ReadLine());
            int wineLitersNeeded = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());

            double totalGrapes = vineyardSqrtMeter * grapesPerSqrtMeter;
            double totalWine = (40 / 100.0) * (totalGrapes / 2.5);
            double difference = totalWine - wineLitersNeeded;

            if (totalWine >= wineLitersNeeded)
            {
                double wineLitersPerWorker = Math.Ceiling(difference / workersCount);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(difference)} liters left -> {wineLitersPerWorker} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(difference))} liters wine needed.");
            }
        }
    }
}
