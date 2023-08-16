using System;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowsCount = gardenDimensions[0];
            int colsCount = gardenDimensions[1];

            int[,] garden = new int[rowsCount, colsCount];

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                if (IsInside(row, col, rowsCount, colsCount))
                {
                    for (int currentRow = 0; currentRow < rowsCount; currentRow++)
                    {
                        if (currentRow != row)
                        {
                            garden[currentRow, col]++;
                        }
                    }
                    for (int currentCol = 0; currentCol < colsCount; currentCol++)
                    {
                        garden[row, currentCol]++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col, int rowsCount, int colsCount)
        {
            if (row >= 0 && row < rowsCount
                && col >= 0 && col < colsCount)
            {
                return true;
            }

            return false;
        }
    }
}
