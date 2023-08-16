using System;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            if (matrixSize < 3)
            {
                Console.WriteLine(0);

                Environment.Exit(0);
            }

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, matrixSize, matrix);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        private static int CountAttackedKnights(int row, int col, int matrixSize, char[,] matrix)
        {
            int attackedKnights = 0;

            // horizontal left-up
            if (IsCellValid(row - 1, col - 2, matrixSize))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // horizontal left-down
            if (IsCellValid(row + 1, col - 2, matrixSize))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // horizontal right-up
            if (IsCellValid(row - 1, col + 2, matrixSize))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // horizontal right-down
            if (IsCellValid(row + 1, col + 2, matrixSize))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // vertical up-left
            if (IsCellValid(row - 2, col - 1, matrixSize))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            // vertical up-right
            if (IsCellValid(row - 2, col + 1, matrixSize))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            // vertical down-left
            if (IsCellValid(row + 2, col - 1, matrixSize))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            // vertical down-right
            if (IsCellValid(row + 2, col + 1, matrixSize))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        private static bool IsCellValid(int row, int col, int matrixSize)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
    }
}
