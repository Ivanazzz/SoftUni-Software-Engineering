using System;

namespace SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string rowData = Console.ReadLine();

                for (int column = 0; column < matrixSize; column++)
                {
                    matrix[row, column] = (char)rowData[column];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrixSize; row++)
            {
                for (int column = 0; column < matrixSize; column++)
                {
                    if (matrix[row, column] == symbol)
                    {
                        Console.WriteLine($"({row}, {column})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
