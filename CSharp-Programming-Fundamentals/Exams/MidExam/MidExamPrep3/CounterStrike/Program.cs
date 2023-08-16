using System;

namespace CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int wonGames = 0;

            string command = Console.ReadLine();
            while(command != "End of battle")
            {
                int distance = int.Parse(command);
                if(distance <= initialEnergy)
                {
                    initialEnergy -= distance;
                    wonGames++;
                    if(wonGames % 3 == 0)
                    {
                        initialEnergy += wonGames;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonGames} won battles and {initialEnergy} energy");
                    Environment.Exit(0);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wonGames}. Energy left: {initialEnergy}");
        }
    }
}
