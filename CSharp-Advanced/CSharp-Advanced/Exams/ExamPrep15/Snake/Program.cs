using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] territory = new char[size, size];
            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = rowData[col];

                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodEaten = 0;
            bool isInside = true;

            while (foodEaten < 10)
            {
                string direction = Console.ReadLine();
                territory[snakeRow, snakeCol] = '.';

                switch (direction)
                {
                    case "up":
                        snakeRow--;
                        Move(ref snakeRow, ref snakeCol, ref isInside, ref foodEaten, size, territory);
                        break;
                    case "down":
                        snakeRow++;
                        Move(ref snakeRow, ref snakeCol, ref isInside, ref foodEaten, size, territory);
                        break;
                    case "left":
                        snakeCol--;
                        Move(ref snakeRow, ref snakeCol, ref isInside, ref foodEaten, size, territory);
                        break;
                    case "right":
                        snakeCol++;
                        Move(ref snakeRow, ref snakeCol, ref isInside, ref foodEaten, size, territory);
                        break;
                }

                if (!isInside)
                {
                    Console.WriteLine("Game over!");

                    break;
                }
            }

            if (foodEaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintTerritory(size, territory);
        }

        private static void Move(ref int snakeRow, ref int snakeCol, ref bool isInside, ref int foodEaten, int size, char[,] territory)
        {
            if (IsOutside(snakeRow, snakeCol, size))
            {
                isInside = false;

                return;
            }

            if (territory[snakeRow, snakeCol] == '*')
            {
                foodEaten++;
            }
            else if (territory[snakeRow, snakeCol] == 'B')
            {
                territory[snakeRow, snakeCol] = '.';
                bool isFound = false;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (territory[row, col] == 'B')
                        {
                            snakeRow = row;
                            snakeCol = col;
                            isFound = true;

                            break;
                        }
                    }

                    if (isFound)
                    {
                        break;
                    }
                }
            }

            territory[snakeRow, snakeCol] = 'S';
        }

        private static bool IsOutside(int snakeRow, int snakeCol, int size)
        {
            if (snakeRow < 0 || snakeRow >= size
                || snakeCol < 0 || snakeCol >= size)
            {
                return true;
            }

            return false;
        }

        private static void PrintTerritory(int size, char[,] territory)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
