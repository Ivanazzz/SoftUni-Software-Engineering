using System;

namespace GameNumberWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstPlayersName = Console.ReadLine();
            string secondPlayersName = Console.ReadLine();

            int firstPlayersPoints = 0;
            int secondPlayersPoints = 0;
            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "End of game")
            {
                int firstPlayersCard = int.Parse(command);
                int secondPlayersCard = int.Parse(Console.ReadLine());

                if (firstPlayersCard > secondPlayersCard)
                {
                    firstPlayersPoints += firstPlayersCard - secondPlayersCard;
                }
                else if (secondPlayersCard > firstPlayersCard)
                {
                    secondPlayersPoints += secondPlayersCard - firstPlayersCard;
                }
                else if (firstPlayersCard == secondPlayersCard)
                {
                    Console.WriteLine("Number wars!");
                    isValid = false;

                    int firstPlayersLastCard = int.Parse(Console.ReadLine());
                    int secondPlayersLastCard = int.Parse(Console.ReadLine());

                    if (firstPlayersLastCard > secondPlayersLastCard)
                    {
                        Console.WriteLine($"{firstPlayersName} is winner with {firstPlayersPoints} points");
                    }
                    else if (secondPlayersLastCard > firstPlayersLastCard)
                    {
                        Console.WriteLine($"{secondPlayersName} is winner with {secondPlayersPoints} points");
                    }

                    break;
                }

                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"{firstPlayersName} has {firstPlayersPoints} points");
                Console.WriteLine($"{secondPlayersName} has {secondPlayersPoints} points");
            }
        }
    }
}
