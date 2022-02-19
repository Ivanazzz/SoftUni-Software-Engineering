using System;

namespace TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int totalWins = 0;
            int totalLoses = 0;
            double totalMoney = 0;

            for (int day = 1; day <= days; day++)
            {
                int winsPerDay = 0;
                int losesPerDay = 0;
                double moneyPerDay = 0;

                while (true)
                {
                    string sport = Console.ReadLine();
                    if (sport == "Finish")
                    {
                        break;
                    }
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        winsPerDay++;
                        moneyPerDay += 20;
                    }
                    else
                    {
                        losesPerDay++;
                    }
                }

                if (winsPerDay > losesPerDay)
                {
                    moneyPerDay += moneyPerDay * 0.1;
                }

                totalMoney += moneyPerDay;
                totalWins += winsPerDay;
                totalLoses += losesPerDay;
            }

            if (totalWins > totalLoses)
            {
                totalMoney += totalMoney * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:F2}");
            }
            else if (totalWins < totalLoses)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:F2}");
            }
        }
    }
}
