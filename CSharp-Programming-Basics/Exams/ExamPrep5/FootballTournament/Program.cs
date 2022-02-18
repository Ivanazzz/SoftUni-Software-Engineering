using System;

namespace FootballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string footballTeamsName = Console.ReadLine();
            int totalPlayedGames = int.Parse(Console.ReadLine());

            if (totalPlayedGames == 0)
            {
                Console.WriteLine($"{footballTeamsName} hasn't played any games during this season.");
                return;
            }

            int totalPoints = 0;
            int wins = 0;
            int draws = 0;
            int loses = 0;

            for (int game = 1; game <= totalPlayedGames; game++)
            {
                char result = char.Parse(Console.ReadLine());
                switch (result)
                {
                    case 'W':
                        totalPoints += 3;
                        wins++;
                        break;
                    case 'D':
                        totalPoints++;
                        draws++;
                        break;
                    case 'L':
                        loses++;
                        break;
                }
            }

            Console.WriteLine($"{footballTeamsName} has won {totalPoints} points during this season.");
            Console.WriteLine("Total stats:");
            Console.WriteLine($"## W: {wins}");
            Console.WriteLine($"## D: {draws}");
            Console.WriteLine($"## L: {loses}");
            Console.WriteLine($"Win rate: {(wins * 1.00 / totalPlayedGames * 100):F2}%");
        }
    }
}
