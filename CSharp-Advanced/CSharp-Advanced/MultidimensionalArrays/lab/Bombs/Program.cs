using System;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] bombsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsInfo.Length; i++)
            {
                int[] currentBomb = bombsInfo[i].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                int rowIndex = currentBomb[0];
                int columnIndex = currentBomb[1];
                int value = matrix[rowIndex, columnIndex];

                if (value > 0)
                {
                    int startRow = rowIndex - 1;
                    int startCol = columnIndex - 1;
                    int endRow = rowIndex + 1;
                    int endCol = columnIndex + 1;

                    IsValid(ref startRow, ref startCol, ref endRow, ref endCol, matrixSize);
                    Bomb(startRow, startCol, endRow, endCol, value, matrix);
                }
            }

            int activeCount = 0;
            int sum = 0;

            Result(ref activeCount, ref sum, matrixSize, matrix);
            PrintMatrix(activeCount, sum, matrixSize, matrix);
        }

        private static void IsValid(ref int startRow, ref int startCol, ref int endRow, ref int endCol, int matrixSize)
        {
            if (startRow < 0)
            {
                startRow = 0;
            }
            if (startCol < 0)
            {
                startCol = 0;
            }
            if (endRow > matrixSize - 1)
            {
                endRow = matrixSize - 1;
            }
            if (endCol > matrixSize - 1)
            {
                endCol = matrixSize - 1;
            }
        }

        private static void Bomb(int startRow, int startCol, int endRow, int endCol, int value, int[,] matrix)
        {
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        matrix[row, col] -= value;
                    }
                }
            }
        }

        private static void Result(ref int activeCount, ref int sum, int matrixSize, int[,] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        activeCount++;
                        sum += matrix[row, col];
                    }
                }
            }
        }

        private static void PrintMatrix(int activeCount, int sum, int matrixSize, int[,] matrix)
        {
            Console.WriteLine($"Alive cells: {activeCount}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
