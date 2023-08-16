using System;
using System.Linq;

namespace DynamicSubmatrixWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int submatrixRows = int.Parse(Console.ReadLine());
            int submatrixCols = int.Parse(Console.ReadLine());
            int[] matrixInfo = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int maxSum = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = 0;

                    for (int subRow = 0; subRow < submatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < submatrixCols; subCol++)
                        {
                            sum += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            for (int subRow = 0; subRow < submatrixRows; subRow++)
            {
                for (int subCol = 0; subCol < submatrixCols; subCol++)
                {
                    Console.Write($"{matrix[startRow + subRow, startCol + subCol]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
