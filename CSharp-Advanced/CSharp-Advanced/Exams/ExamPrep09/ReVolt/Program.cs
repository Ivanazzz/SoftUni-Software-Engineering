using System;

namespace ReVolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < numberOfCommands; i++)
            {
                string direction = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                switch (direction)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                }

                Move(size, matrix, ref playerRow, ref playerCol, direction);
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(size, matrix);
        }

        private static void Move(int size, char[,] matrix, ref int playerRow, ref int playerCol, string direction)
        {
            MakePositionValid(ref playerRow, ref playerCol, size);

            if (matrix[playerRow, playerCol] == 'F')
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player won!");
                PrintMatrix(size, matrix);

                Environment.Exit(0);
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                switch (direction)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                }

                Move(size, matrix, ref playerRow, ref playerCol, direction);
            }
            else if (matrix[playerRow, playerCol] == 'T')
            {
                switch (direction)
                {
                    case "up":
                        playerRow++;
                        break;
                    case "down":
                        playerRow--;
                        break;
                    case "left":
                        playerCol++;
                        break;
                    case "right":
                        playerCol--;
                        break;
                }

                Move(size, matrix, ref playerRow, ref playerCol, direction);
            }

            matrix[playerRow, playerCol] = 'f';
        }

        private static void MakePositionValid(ref int playerRow, ref int playerCol, int size)
        {
            if (playerRow < 0)
                playerRow = size - 1;
            if (playerRow >= size)
                playerRow = 0;
            if (playerCol < 0)
                playerCol = size - 1;
            if (playerCol >= size)
                playerCol = 0;
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
