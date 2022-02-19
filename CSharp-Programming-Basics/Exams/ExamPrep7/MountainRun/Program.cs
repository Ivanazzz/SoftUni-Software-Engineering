using System;

namespace MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeFor1MeterInSeconds = double.Parse(Console.ReadLine());

            double totalSeconds = distanceInMeters * timeFor1MeterInSeconds;
            double delaySeconds = Math.Floor(distanceInMeters / 50) * 30;
            totalSeconds += delaySeconds;

            if (totalSeconds < recordInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {totalSeconds:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {(totalSeconds - recordInSeconds):F2} seconds slower.");
            }
        }
    }
}
