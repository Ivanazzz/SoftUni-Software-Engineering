using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int startupPoints = int.Parse(Console.ReadLine());

            int tournamentPoints = 0;
            int winsCounter = 0;

            for (int i = 0; i < tournamentsCount; i++)
            {
                string position = Console.ReadLine();

                switch (position)
                {
                    case "W":
                        tournamentPoints += 2000;
                        winsCounter++;
                        break;
                    case "F":
                        tournamentPoints += 1200;
                        break;
                    case "SF":
                        tournamentPoints += 720;
                        break;

                }
            }

            int totalPoints = startupPoints + tournamentPoints;
            double averagePointsPerTournament = Math.Floor(tournamentPoints * 1.00 / tournamentsCount);
            double percentWonTournaments = winsCounter * 1.00 / tournamentsCount * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {averagePointsPerTournament}");
            Console.WriteLine($"{percentWonTournaments:F2}%");
        }
    }
}
