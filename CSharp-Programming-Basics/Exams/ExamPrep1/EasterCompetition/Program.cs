using System;

namespace EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sweetBreadsQuantity = int.Parse(Console.ReadLine());

            int maxPoints = 0;
            string winnersName = "";

            for (int player = 1; player <= sweetBreadsQuantity; player++)
            {
                bool isValid = false;
                int points = 0;
                string bakersName = Console.ReadLine();

                string command = Console.ReadLine();

                while (command != "Stop")
                {
                    int currentPoints = int.Parse(command);
                    points += currentPoints;
                    command = Console.ReadLine();
                }

                if (points > maxPoints)
                {
                    maxPoints = points;
                    winnersName = bakersName;
                    isValid = true;
                }

                Console.WriteLine($"{bakersName} has {points} points.");
                if (isValid)
                {
                    Console.WriteLine($"{bakersName} is the new number 1!");
                }
            }

            Console.WriteLine($"{winnersName} won competition with {maxPoints} points!");
        }
    }
}
