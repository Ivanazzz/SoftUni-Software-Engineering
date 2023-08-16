using System;

namespace TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdventure = int.Parse(Console.ReadLine());
            int numberOfPlayers = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());


            double totalWater = daysOfAdventure * numberOfPlayers * water;
            double totalFood = daysOfAdventure * numberOfPlayers * food;

            for (int day = 1; day <= daysOfAdventure; day++)
            {
                double currentEnergyLoss = double.Parse(Console.ReadLine());
                groupsEnergy -= currentEnergyLoss;

                if (groupsEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    Environment.Exit(0);
                }

                if (day % 2 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.05;
                    totalWater -= totalWater * 0.3;
                }
                if (day % 3 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.1;
                    totalFood -= totalFood / numberOfPlayers;
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");
        }
    }
}
