using System;

namespace Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            int secondsPer100meters = int.Parse(Console.ReadLine());

            int totalSeconds = (minutes * 60) + seconds;
            double timeDecrease = length / 120;
            double totalTimeDecrease = timeDecrease * 2.5;
            double playersTotalTime = (length / 100) * secondsPer100meters - totalTimeDecrease;

            if (playersTotalTime <= totalSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {playersTotalTime:F3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {(playersTotalTime - totalSeconds):F3} second slower.");
            }
        }
    }
}
