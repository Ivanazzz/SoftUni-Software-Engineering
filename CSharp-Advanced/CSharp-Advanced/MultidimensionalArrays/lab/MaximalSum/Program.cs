using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSize = 3;

            int[] matrixInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row <= rows - squareSize; row++)
            {
                for (int col = 0; col <= cols - squareSize; col++)
                {
                    int currentSum = 0;

                    for (int currentRow = row; currentRow < row + squareSize; currentRow++)
                    {
                        for (int currentCol = col; currentCol < col + squareSize; currentCol++)
                        {
                            currentSum += matrix[currentRow, currentCol];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRow; row < startRow + squareSize; row++)
            {
                List<int> resultRow = new List<int>();

                for (int col = startCol; col < startCol + squareSize; col++)
                {
                    resultRow.Add(matrix[row, col]);
                }

                Console.WriteLine(string.Join(' ', resultRow));
            }
        }
    }
}
