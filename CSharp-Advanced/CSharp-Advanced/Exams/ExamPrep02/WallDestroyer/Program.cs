using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            char[,] wall = new char[wallSize, wallSize];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < wallSize; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < wallSize; col++)
                {
                    wall[row, col] = rowData[col];

                    if (wall[row, col] == 'V')
                    {
                        playerRow = row;
                        playerCol = col;
                        wall[playerRow, playerCol] = '*';
                    }
                }
            }

            int holesCount = 1;
            int rodsCount = 0;
            bool isAlive = true;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        Move(-1, 0, ref playerRow, ref playerCol, ref holesCount, ref rodsCount, ref isAlive, wall);
                        break;
                    case "down":
                        Move(+1, 0, ref playerRow, ref playerCol, ref holesCount, ref rodsCount, ref isAlive, wall);
                        break;
                    case "left":
                        Move(0, -1, ref playerRow, ref playerCol, ref holesCount, ref rodsCount, ref isAlive, wall);
                        break;
                    case "right":
                        Move(0, +1, ref playerRow, ref playerCol, ref holesCount, ref rodsCount, ref isAlive, wall);
                        break;
                }

                if (!isAlive)
                {
                    break;
                }
            }

            if (isAlive)
            {
                wall[playerRow, playerCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }

            PrintWall(wallSize, wall, playerRow, playerCol);
        }

        private static void Move(int row, int col, ref int playerRow, ref int playerCol, ref int holesCount, ref int rodsCount, ref bool isAlive, char[,] wall)
        {
            if (IsInside(playerRow + row, playerCol + col, wall.GetLength(0)))
            {
                if (wall[playerRow + row, playerCol + col] == 'C')
                {
                    holesCount++;
                    wall[playerRow + row, playerCol + col] = 'E';
                    isAlive = false;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                }
                else if (wall[playerRow + row, playerCol + col] == 'R')
                {
                    rodsCount++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[playerRow + row, playerCol + col] == '*')
                {
                    playerRow += row;
                    playerCol += col;
                    Console.WriteLine($"The wall is already destroyed at position [{playerRow}, {playerCol}]!");
                }
                else
                {
                    playerRow += row;
                    playerCol += col;
                    holesCount++;
                    wall[playerRow, playerCol] = '*';
                }
            }
        }

        private static bool IsInside(int playerRow, int playerCol, int wallSize)
        {
            return playerRow >= 0 && playerRow < wallSize
                && playerCol >= 0 && playerCol < wallSize;
        }

        private static void PrintWall(int wallSize, char[,] wall, int playerRow, int playerCol)
        {
            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
