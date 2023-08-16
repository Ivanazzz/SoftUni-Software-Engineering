using System;

namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;
            bool hasPlayerWon = false;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int points = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                bool isInField = true;

                switch (command)
                {
                    case "up":
                        isInField = CheckIfIsInField(playerRow - 1, playerCol, field);
                        if (!isInField)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        field[playerRow, playerCol] = '-';
                        playerRow--;

                        MovePlayer(n, field, ref playerRow, ref playerCol, ref points);
                        break;
                    case "down":
                        isInField = CheckIfIsInField(playerRow + 1, playerCol, field);
                        if (!isInField)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        field[playerRow, playerCol] = '-';
                        playerRow++;

                        MovePlayer(n, field, ref playerRow, ref playerCol, ref points);
                        break;
                    case "left":
                        isInField = CheckIfIsInField(playerRow, playerCol - 1, field);
                        if (!isInField)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        field[playerRow, playerCol] = '-';
                        playerCol--;

                        MovePlayer(n, field, ref playerRow, ref playerCol, ref points);
                        break;
                    case "right":
                        isInField = CheckIfIsInField(playerRow, playerCol + 1, field);
                        if (!isInField)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        field[playerRow, playerCol] = '-';
                        playerCol++;

                        MovePlayer(n, field, ref playerRow, ref playerCol, ref points);
                        break;
                }

                if (points >= 25)
                {
                    hasPlayerWon = true;
                    break;
                }
            }

            if (hasPlayerWon)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            PrintField(n, field);
        }

        private static bool CheckIfIsInField(int playerRow, int playerCol, char[,] field)
        {
            return playerRow >= 0
                && playerRow < field.GetLength(0)
                && playerCol >= 0
                && playerCol < field.GetLength(1);
        }

        private static void MovePlayer(int n, char[,] field, ref int playerRow, ref int playerCol, ref int points)
        {
            if (char.IsDigit(field[playerRow, playerCol]))
            {
                points += field[playerRow, playerCol] - '0';
            }
            else if (field[playerRow, playerCol] == 'S')
            {
                field[playerRow, playerCol] = '-';

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (field[row, col] == 'S')
                        {
                            playerRow = row;
                            playerCol = col;
                            points -= 3;
                        }
                    }
                }
            }

            field[playerRow, playerCol] = 'M';
        }

        private static void PrintField(int n, char[,] field)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
