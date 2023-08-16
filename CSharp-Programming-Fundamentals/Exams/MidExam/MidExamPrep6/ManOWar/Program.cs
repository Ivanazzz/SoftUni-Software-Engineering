using System;
using System.Linq;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShipStatus = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();
            int[] warshipStatus = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();
            int maximumHealthCapacity = int.Parse(Console.ReadLine());

            bool stalemate = true;

            string command = Console.ReadLine();
            while(command != "Retire" && stalemate)
            {
                string[] tokens = command.Split();
                string operation = tokens[0];

                switch (operation)
                {
                    case "Fire":
                        int indexFire = int.Parse(tokens[1]);
                        int damageFire = int.Parse(tokens[2]);
                        Fire(indexFire, damageFire, warshipStatus);

                        foreach (int section in warshipStatus)
                        {
                            if (section <= 0)
                            {
                                Environment.Exit(0);
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        int damageDefened = int.Parse(tokens[3]);
                        Defend(startIndex, endIndex, damageDefened, pirateShipStatus);

                        foreach (int section in pirateShipStatus)
                        {
                            if (section <= 0)
                            {
                                Environment.Exit(0);
                            }
                        }
                        break;
                    case "Repair":
                        int indexRepair = int.Parse(tokens[1]);
                        int health = int.Parse(tokens[2]);
                        Repair(indexRepair, health, maximumHealthCapacity, pirateShipStatus);
                        break;
                    case "Status":
                        double healthNeeded = maximumHealthCapacity * 0.2;
                        Status(healthNeeded, pirateShipStatus);
                        break;
                }

                command = Console.ReadLine();
            }

            if(stalemate)
            {
                Console.WriteLine($"Pirate ship status: {pirateShipStatus.Sum()}");
                Console.WriteLine($"Warship status: {warshipStatus.Sum()}");
            }
        }

        private static void Fire(int section, int damageFire, int[] warshipStatus)
        {
            if (section >= 0 && section < warshipStatus.Length)
            {
                warshipStatus[section] -= damageFire;
                if (warshipStatus[section] <= 0)
                {
                    Console.WriteLine("You won! The enemy ship has sunken.");
                    return;
                }
            }
        }

        private static void Defend(int startIndex, int endIndex, int damageDefened, int[] pirateShipStatus)
        {
            if (startIndex >= 0 && startIndex < pirateShipStatus.Length &&
                endIndex >= 0 && endIndex < pirateShipStatus.Length)
            {
                for (int section = startIndex; section <= endIndex; section++)
                {
                    pirateShipStatus[section] -= damageDefened;
                    if (pirateShipStatus[section] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        return;
                    }
                }
            }
        }

        private static void Repair(int section, int health, int maximumHealthCapacity, int[] pirateShipStatus)
        {
            if (section >= 0 && section < pirateShipStatus.Length)
            {
                pirateShipStatus[section] += health;
                if (pirateShipStatus[section] > maximumHealthCapacity)
                {
                    pirateShipStatus[section] = maximumHealthCapacity;
                }
            }
        }

        private static void Status(double healthNeeded, int[] pirateShipStatus)
        {
            int count = 0;
            for (int section = 0; section < pirateShipStatus.Length; section++)
            {
                int currentSection = pirateShipStatus[section];
                if (currentSection < healthNeeded)
                {
                    count++;
                }
            }

            Console.WriteLine($"{count} sections need repair.");
        }
    }
}
