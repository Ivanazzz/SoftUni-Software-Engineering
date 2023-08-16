using System;
using System.Linq;

namespace SumMatrixColumns
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
            int columns = matrixInfo[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = rowData[column];
                }
            }

            for (int column = 0; column < columns; column++)
            {
                int currentColumnSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    currentColumnSum += matrix[row, column];
                }

                Console.WriteLine(currentColumnSum);
            }
        }
    }
}
