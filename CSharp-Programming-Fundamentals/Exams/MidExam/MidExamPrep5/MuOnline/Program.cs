using System;
using System.Linq;

namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|")
                .ToArray();
            int health = 100;
            int bitcoins = 0;

            for (int room = 0; room < rooms.Length; room++)
            {
                string[] tokens = rooms[room].Split();
                string roomType = tokens[0];
                int points = int.Parse(tokens[1]);

                switch (roomType)
                {
                    case "potion":
                        int canAccept = 100 - health;
                        if (canAccept >= points)
                        {
                            health += points;
                            Console.WriteLine($"You healed for {points} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        else
                        {
                            health = 100;
                            Console.WriteLine($"You healed for {canAccept} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        break;
                    case "chest":
                        bitcoins += points;
                        Console.WriteLine($"You found {points} bitcoins.");
                        break;
                    default:
                        if (health > points)
                        {
                            health = health - points;
                            Console.WriteLine($"You slayed {roomType}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {roomType}.");
                            Console.WriteLine($"Best room: {room + 1}");
                            Environment.Exit(0);
                        }
                        break;
                }
            }

                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
        }
    }
}
