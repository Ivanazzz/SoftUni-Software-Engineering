using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int startupPoints = int.Parse(Console.ReadLine());

            int currentPoints = 0;
            int numberOfWins = 0;

            for (int game = 1; game <= tournamentsCount; game++)
            {
                string result = Console.ReadLine();

                if (result == "W")
                {
                    numberOfWins++;
                    currentPoints += 2000;
                }
                else if (result == "F")
                {
                    currentPoints += 1200;
                }
                else if (result == "SF")
                {
                    currentPoints += 720;
                }
            }

            int totalPoints = startupPoints + currentPoints;
            double averagePointsFromTournaments = currentPoints * 1.00 / tournamentsCount;
            double wonTournamentsPercentage = (numberOfWins * 1.00 / tournamentsCount) * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePointsFromTournaments)}");
            Console.WriteLine($"{wonTournamentsPercentage:F2}%");
        }
    }
}
