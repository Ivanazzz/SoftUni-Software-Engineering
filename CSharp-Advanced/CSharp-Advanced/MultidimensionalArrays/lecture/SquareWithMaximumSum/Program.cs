using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            int squareStartRow = 0;
            int squareStartCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = 0;

                    sum += matrix[row, col];
                    sum += matrix[row + 1, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        squareStartRow = row;
                        squareStartCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[squareStartRow, squareStartCol]} {matrix[squareStartRow, squareStartCol + 1]}");
            Console.WriteLine($"{matrix[squareStartRow + 1, squareStartCol]} {matrix[squareStartRow + 1, squareStartCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
