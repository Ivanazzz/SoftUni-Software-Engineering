using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorySize = int.Parse(Console.ReadLine());

            char[,] armory = new char[armorySize, armorySize];
            int armyOfficerRow = 0;
            int armyOfficerCol = 0;

            for (int row = 0; row < armorySize; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < armorySize; col++)
                {
                    armory[row, col] = rowData[col];

                    if (armory[row, col] == 'A')
                    {
                        armyOfficerRow = row;
                        armyOfficerCol = col;
                    }
                }
            }

            int paidGoldCoins = 0;

            while (paidGoldCoins < 65)
            {
                string direction = Console.ReadLine();
                armory[armyOfficerRow, armyOfficerCol] = '-';

                switch (direction)
                {
                    case "up":
                        armyOfficerRow--;
                        Move(ref armyOfficerRow, ref armyOfficerCol, ref paidGoldCoins, armorySize, armory);
                        break;
                    case "down":
                        armyOfficerRow++;
                        Move(ref armyOfficerRow, ref armyOfficerCol, ref paidGoldCoins, armorySize, armory);
                        break;
                    case "left":
                        armyOfficerCol--;
                        Move(ref armyOfficerRow, ref armyOfficerCol, ref paidGoldCoins, armorySize, armory);
                        break;
                    case "right":
                        armyOfficerCol++;
                        Move(ref armyOfficerRow, ref armyOfficerCol, ref paidGoldCoins, armorySize, armory);
                        break;
                }
            }

            Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {paidGoldCoins} gold coins.");
            PrintArmory(armorySize, armory);
        }

        private static void Move(ref int armyOfficerRow, ref int armyOfficerCol, ref int paidGoldCoins, int armorySize, char[,] armory)
        {
            if (armyOfficerRow < 0 || armyOfficerRow >= armorySize
                || armyOfficerCol < 0 || armyOfficerCol >= armorySize)
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {paidGoldCoins} gold coins.");
                PrintArmory(armorySize, armory);

                Environment.Exit(0);
            }

            if (char.IsDigit(armory[armyOfficerRow, armyOfficerCol]))
            {
                paidGoldCoins += armory[armyOfficerRow, armyOfficerCol] - '0';
                armory[armyOfficerRow, armyOfficerCol] = 'A';
            }
            else
            {
                armory[armyOfficerRow, armyOfficerCol] = '-';

                for (int row = 0; row < armorySize; row++)
                {
                    for (int col = 0; col < armorySize; col++)
                    {
                        if (armory[row, col] == 'M')
                        {
                            armory[row, col] = 'A';
                            armyOfficerRow = row;
                            armyOfficerCol = col;
                        }
                    }
                }
            }
        }

        private static void PrintArmory(int armorySize, char[,] armory)
        {
            for (int row = 0; row < armorySize; row++)
            {
                for (int col = 0; col < armorySize; col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
