using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read the matrix
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;
            int totalBranchesCount = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        totalBranchesCount++;
                    }
                }
            }

            // Process the input commands
            Stack<char> branches = new Stack<char>();
            int collectedBranches = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        MoveTo(ref playerRow, ref playerCol, playerRow - 1, playerCol, ref collectedBranches, command, matrix, branches);
                        break;
                    case "down":
                        MoveTo(ref playerRow, ref playerCol, playerRow + 1, playerCol, ref collectedBranches, command, matrix, branches);
                        break;
                    case "left":
                        MoveTo(ref playerRow, ref playerCol, playerRow, playerCol - 1, ref collectedBranches, command, matrix, branches);
                        break;
                    case "right":
                        MoveTo(ref playerRow, ref playerCol, playerRow, playerCol + 1, ref collectedBranches, command, matrix, branches);
                        break;
                }

                if (collectedBranches == totalBranchesCount)
                {
                    Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                    PrintMatrix(matrix, n);

                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranchesCount - collectedBranches} branches left.");
            PrintMatrix(matrix, n);
        }

        private static void MoveTo(ref int playerRow, ref int playerCol, int newPlayerRow, int newPlayerCol,
            ref int collectedBranches, string command, char[,] matrix, Stack<char> branches)
        {
            // Outside of the pond
            if (newPlayerRow < 0 || newPlayerRow >= matrix.GetLength(0) ||
                newPlayerCol < 0 || newPlayerCol >= matrix.GetLength(1))
            {
                if (branches.Count > 0)
                {
                    branches.Pop();

                    return;
                }
            }

            if (char.IsLower(matrix[newPlayerRow, newPlayerCol])) // On a branch
            {
                // Collect the branch
                branches.Push(matrix[newPlayerRow, newPlayerCol]);
                collectedBranches++;
                matrix[playerRow, playerCol] = '-';
                matrix[newPlayerRow, newPlayerCol] = 'B';
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'F') // On a fish
            {
                // Eat the fish, move to new location (and collect the branch if any)
                matrix[newPlayerRow, newPlayerCol] = '-'; // Remove the fish
                matrix[playerRow, playerCol] = '-'; // Remove the beaver

                switch (command)
                {
                    case "up":
                        if (newPlayerRow != 0)
                        {
                            newPlayerRow = 0;
                        }
                        else
                        {
                            newPlayerRow = matrix.GetLength(0) - 1;
                        }
                        break;
                    case "down":
                        if (newPlayerRow != matrix.GetLength(0) - 1)
                        {
                            newPlayerRow = matrix.GetLength(0) - 1;
                        }
                        else
                        {
                            newPlayerRow = 0;
                        }
                        break;
                    case "left":
                        if (newPlayerCol != 0)
                        {
                            newPlayerCol = 0;
                        }
                        else
                        {
                            newPlayerCol = matrix.GetLength(1) - 1;
                        }
                        break;
                    case "right":
                        if (newPlayerCol != matrix.GetLength(1) - 1)
                        {
                            newPlayerCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            newPlayerCol = 0;
                        }
                        break;
                }

                if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                {
                    // Collect the branch
                    branches.Push(matrix[newPlayerRow, newPlayerCol]);
                    collectedBranches++;
                }

                matrix[newPlayerRow, newPlayerCol] = 'B';
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            else // Otherwise
            {
                // Move to the new position
                matrix[playerRow, playerCol] = '-';
                matrix[newPlayerRow, newPlayerCol] = 'B';
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
