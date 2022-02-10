using System;

namespace FootballResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstGameResult = Console.ReadLine();
            string secondGameResult = Console.ReadLine();
            string thirdGameResult = Console.ReadLine();

            int wins = 0;
            int loses = 0;
            int draws = 0;

            string[] firstGameResultsList = firstGameResult.Split(':');
            string[] secondGameResultsList = secondGameResult.Split(':');
            string[] thirdGameResultsList = thirdGameResult.Split(':');

            if (int.Parse(firstGameResultsList[0]) > int.Parse(firstGameResultsList[1]))
            {
                wins++;
            }
            else if (int.Parse(firstGameResultsList[0]) < int.Parse(firstGameResultsList[1]))
            {
                loses++;
            }
            else if (int.Parse(firstGameResultsList[0]) == int.Parse(firstGameResultsList[1]))
            {
                draws++;
            }

            if (int.Parse(secondGameResultsList[0]) > int.Parse(secondGameResultsList[1]))
            {
                wins++;
            }
            else if (int.Parse(secondGameResultsList[0]) < int.Parse(secondGameResultsList[1]))
            {
                loses++;
            }
            else if (int.Parse(secondGameResultsList[0]) == int.Parse(secondGameResultsList[1]))
            {
                draws++;
            }

            if (int.Parse(thirdGameResultsList[0]) > int.Parse(thirdGameResultsList[1]))
            {
                wins++;
            }
            else if (int.Parse(thirdGameResultsList[0]) < int.Parse(thirdGameResultsList[1]))
            {
                loses++;
            }
            else if (int.Parse(thirdGameResultsList[0]) == int.Parse(thirdGameResultsList[1]))
            {
                draws++;
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($" Drawn games: {draws}");
        }
    }
}