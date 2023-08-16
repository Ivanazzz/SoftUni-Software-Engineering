using System;

namespace NameGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string winnersName = "";
            int winnersPoints = 0;

            string playersName = Console.ReadLine();

            while (playersName != "Stop")
            {
                int points = 0;

                for (int i = 0; i < playersName.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number == (int)playersName[i])
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }

                if (points >= winnersPoints)
                {
                    winnersPoints = points;
                    winnersName = playersName;
                }

                playersName = Console.ReadLine();
            }

            Console.WriteLine($"The winner is {winnersName} with {winnersPoints} points!");
        }
    }
}
