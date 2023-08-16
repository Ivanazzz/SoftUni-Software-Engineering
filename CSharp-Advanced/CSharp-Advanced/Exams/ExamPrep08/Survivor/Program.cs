using System;
using System.Linq;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                
                jaggedArray[row] = rowData;
            }

            int collectedTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Gong")
                {
                    break;
                }

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (action == "Find")
                {
                    if (IsInside(row, col, numberOfRows, jaggedArray))
                    {
                        if (jaggedArray[row][col] == 'T')
                        {
                            collectedTokens++;
                            jaggedArray[row][col] = '-';
                        }
                    }
                }
                else
                {
                    string direction = tokens[3];

                    if (IsInside(row, col, numberOfRows, jaggedArray))
                    {
                        if (jaggedArray[row][col] == 'T')
                        {
                            opponentTokens++;
                            jaggedArray[row][col] = '-';
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            switch (direction)
                            {
                                case "up":
                                    row--;
                                    break;
                                case "down":
                                    row++;
                                    break;
                                case "left":
                                    col--;
                                    break;
                                case "right":
                                    col++;
                                    break;
                            }

                            if (!IsInside(row, col, numberOfRows, jaggedArray))
                            {
                                break;
                            }

                            if (jaggedArray[row][col] == 'T')
                            {
                                opponentTokens++;
                                jaggedArray[row][col] = '-';
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool IsInside(int row, int col, int numberOfRows, char[][] jaggedArray)
        {
            if (row >= 0 && row < numberOfRows
                && col >= 0 && col < jaggedArray[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}
