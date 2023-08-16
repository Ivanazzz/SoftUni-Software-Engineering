using System;

namespace PCGameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int soldGamesCount = int.Parse(Console.ReadLine());

            int hearthstoneCount = 0;
            int forniteCount = 0;
            int overwatchCount = 0;
            int othersCount = 0;

            for (int game = 1; game <= soldGamesCount; game++)
            {
                string gamesName = Console.ReadLine();
                if (gamesName == "Hearthstone")
                {
                    hearthstoneCount++;
                }
                else if (gamesName == "Fornite")
                {
                    forniteCount++;
                }
                else if (gamesName == "Overwatch")
                {
                    overwatchCount++;
                }
                else
                {
                    othersCount++;
                }
            }

            double soldHearthstonePercentage = hearthstoneCount * 1.00 / soldGamesCount * 100;
            double soldFornitePercentage = forniteCount * 1.00 / soldGamesCount * 100;
            double soldOverwatchPercentage = overwatchCount * 1.00 / soldGamesCount * 100;
            double soldOthersPercentage = othersCount * 1.00 / soldGamesCount * 100;

            Console.WriteLine($"Hearthstone - {soldHearthstonePercentage:F2}%");
            Console.WriteLine($"Fornite - {soldFornitePercentage:F2}%");
            Console.WriteLine($"Overwatch - {soldOverwatchPercentage:F2}%");
            Console.WriteLine($"Others - {soldOthersPercentage:F2}%");
        }
    }
}
