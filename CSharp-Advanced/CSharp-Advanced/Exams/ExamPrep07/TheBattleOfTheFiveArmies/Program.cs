using System;

namespace TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armourOfTheArmy = int.Parse(Console.ReadLine());
            int sizeOfMap = int.Parse(Console.ReadLine());

            char[][] map = new char[sizeOfMap][];
            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < sizeOfMap; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                map[row] = rowData;

                for (int col = 0; col < rowData.Length; col++)
                {
                    if (map[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;

                        break;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                int enemySpawnRow = int.Parse(tokens[1]);
                int enemySpawnCol = int.Parse(tokens[2]);

                map[enemySpawnRow][enemySpawnCol] = 'O';
                armourOfTheArmy--;

                switch (direction)
                {
                    case "up":
                        Move(ref armyRow, ref armyCol, armyRow - 1, armyCol, ref armourOfTheArmy, sizeOfMap, map);
                        break;
                    case "down":
                        Move(ref armyRow, ref armyCol, armyRow + 1, armyCol, ref armourOfTheArmy, sizeOfMap, map);
                        break;
                    case "left":
                        Move(ref armyRow, ref armyCol, armyRow, armyCol - 1, ref armourOfTheArmy, sizeOfMap, map);
                        break;
                    case "right":
                        Move(ref armyRow, ref armyCol, armyRow, armyCol + 1, ref armourOfTheArmy, sizeOfMap, map);
                        break;
                }
            }
        }

        private static void Move(ref int armyRow, ref int armyCol, int newArmyRow, int newArmyCol, ref int armourOfTheArmy, int sizeOfMap, char[][] map)
        {
            if (IsInside(newArmyRow, newArmyCol, sizeOfMap, map))
            {
                map[armyRow][armyCol] = '-';
                armyRow = newArmyRow;
                armyCol = newArmyCol;

                if (map[armyRow][armyCol] == 'M')
                {
                    map[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armourOfTheArmy}");
                    PrintMap(map);

                    Environment.Exit(0);
                }
                else if (map[armyRow][armyCol] == 'O')
                {
                    armourOfTheArmy -= 2;
                }

                IsArmyOutOfArmour(armourOfTheArmy, armyRow, armyCol, sizeOfMap, map);
                map[armyRow][armyCol] = 'A';
            }
        }

        private static bool IsInside(int newArmyRow, int newArmyCol, int sizeOfMap, char[][] map)
        {
            if (newArmyRow >= 0 && newArmyRow < sizeOfMap
                && newArmyCol >= 0 && newArmyCol < map[newArmyRow].Length)
            {
                return true;
            }

            return false;
        }

        private static void IsArmyOutOfArmour(int armourOfTheArmy, int armyRow, int armyCol, int sizeOfMap, char[][] map)
        {
            if (armourOfTheArmy <= 0)
            {
                map[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                PrintMap(map);

                Environment.Exit(0);
            }
        }

        private static void PrintMap(char[][] map)
        {
            foreach (char[] row in map)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
