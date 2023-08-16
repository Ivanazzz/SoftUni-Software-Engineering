using System;

namespace BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bestPlayersName = "";
            int bestPlayersGoals = 0;
            bool isValid = false;

            string player = Console.ReadLine();
            while (player != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > bestPlayersGoals)
                {
                    bestPlayersGoals = goals;
                    bestPlayersName = player;
                    if (goals >= 10)
                    {
                        isValid = true;
                        break;
                    }
                    if (goals >= 3)
                    {
                        isValid = true;
                    }
                }
                player = Console.ReadLine();
            }

            Console.WriteLine($"{bestPlayersName} is the best player!");
            if (isValid)
            {
                Console.WriteLine($"He has scored {bestPlayersGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayersGoals} goals.");
            }
        }
    }
}
