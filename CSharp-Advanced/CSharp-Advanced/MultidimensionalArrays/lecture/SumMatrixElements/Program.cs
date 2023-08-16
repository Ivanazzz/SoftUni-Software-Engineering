using System;
using System.Linq;

namespace SumMatrixElements
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
            int elementsSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = rowData[column];
                    elementsSum += rowData[column];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(elementsSum);
        }
    }
}
