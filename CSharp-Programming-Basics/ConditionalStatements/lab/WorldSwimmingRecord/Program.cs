using System;

namespace WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double metersPerSecond = double.Parse(Console.ReadLine());

            double secondsSwimming = meters * metersPerSecond;
            double delaySeconds = Math.Floor(meters / 15) * 12.5;
            double totalSecondsSum = secondsSwimming + delaySeconds;

            if (totalSecondsSum < recordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalSecondsSum:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalSecondsSum - recordSeconds):F2} seconds slower.");
            }
        }
    }
}
