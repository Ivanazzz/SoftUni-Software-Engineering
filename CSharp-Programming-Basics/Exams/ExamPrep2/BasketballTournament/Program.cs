using System;

namespace BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tournamentsName = Console.ReadLine();

            int wonGames = 0;
            int lostGames = 0;
            int totalPlayedGames = 0;

            while (tournamentsName != "End of tournaments")
            {
                int numberOfPlayedGames = int.Parse(Console.ReadLine());
                totalPlayedGames += numberOfPlayedGames;

                for (int game = 1; game <= numberOfPlayedGames; game++)
                {
                    int firstTeamPoints = int.Parse(Console.ReadLine());
                    int secondTeamPoints = int.Parse(Console.ReadLine());

                    if (firstTeamPoints > secondTeamPoints)
                    {
                        wonGames++;
                        Console.WriteLine($"Game {game} of tournament {tournamentsName}: win with {firstTeamPoints - secondTeamPoints} points.");
                    }
                    else if (secondTeamPoints > firstTeamPoints)
                    {
                        lostGames++;
                        Console.WriteLine($"Game {game} of tournament {tournamentsName}: lost with {secondTeamPoints - firstTeamPoints} points.");
                    }
                }

                tournamentsName = Console.ReadLine();
            }

            double wonGamesPercentage = (wonGames * 1.00 / totalPlayedGames) * 100;
            double lostGamesPercentage = (lostGames * 1.00 / totalPlayedGames) * 100;

            Console.WriteLine($"{wonGamesPercentage:F2}% matches win");
            Console.WriteLine($"{lostGamesPercentage:F2}% matches lost");
        }
    }
}
