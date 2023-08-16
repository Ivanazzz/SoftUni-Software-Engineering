using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int forestSize = int.Parse(Console.ReadLine());

            char[,] forest = new char[forestSize, forestSize];

            for (int row = 0; row < forestSize; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < forestSize; col++)
                {
                    forest[row, col] = rowData[col];
                }
            }

            Dictionary<char, int> countByTruffle = new Dictionary<char, int>()
            {
                { 'B', 0 },
                { 'S', 0 },
                { 'W', 0 },
            };
            int trufflesEaten = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop the hunt")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (action == "Collect")
                {
                    if (forest[row, col] != '-')
                    {
                        countByTruffle[forest[row, col]]++;
                        forest[row, col] = '-';
                    }
                }
                else if (action == "Wild_Boar")
                {
                    string direction = tokens[3];

                    switch (direction)
                    {
                        case "up":
                            for (int currentRow = row; currentRow >= 0; currentRow -= 2)
                            {
                                Eat(forest, ref trufflesEaten, currentRow, col);
                            }
                            break;
                        case "down":
                            for (int currentRow = row; currentRow < forestSize; currentRow += 2)
                            {
                                Eat(forest, ref trufflesEaten, currentRow, col);
                            }
                            break;
                        case "left":
                            for (int currentCol = col; currentCol >= 0; currentCol -= 2)
                            {
                                Eat(forest, ref trufflesEaten, row, currentCol);
                            }
                            break;
                        case "right":
                            for (int currentCol = col; currentCol < forestSize; currentCol += 2)
                            {
                                Eat(forest, ref trufflesEaten, row, currentCol);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {countByTruffle['B']} black, {countByTruffle['S']} summer, and {countByTruffle['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {trufflesEaten} truffles.");

            for (int row = 0; row < forestSize; row++)
            {
                for (int col = 0; col < forestSize; col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Eat(char[,] forest, ref int trufflesEaten, int row, int col)
        {
            if (forest[row, col] != '-')
            {
                trufflesEaten++;
                forest[row, col] = '-';
            }
        }
    }
}
