using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            List<string> coordinates = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[,] field = new string[size, size];
            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;

            for (int row = 0; row < size; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == "<")
                    {
                        firstPlayerShipsCount++;
                    }
                    else if (field[row, col] == ">")
                    {
                        secondPlayerShipsCount++;
                    }
                }
            }

            int sunkShipsCount = 0;

            while (coordinates.Any())
            {
                string[] currentCoordinates = coordinates[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                coordinates.RemoveAt(0);
                int attackRow = int.Parse(currentCoordinates[0]);
                int attackCol = int.Parse(currentCoordinates[1]);

                if (IsInside(attackRow, attackCol, size))
                {
                    switch (field[attackRow, attackCol])
                    {
                        case "<":
                            firstPlayerShipsCount--;
                            sunkShipsCount++;
                            break;
                        case ">":
                            secondPlayerShipsCount--;
                            sunkShipsCount++;
                            break;
                        case "#":
                            int startAttackRow = attackRow - 1;
                            int endAttackRow = attackRow + 1;
                            int startAttackCol = attackCol - 1;
                            int endAttackCol = attackCol + 1;

                            MakeItValid(ref startAttackRow, ref endAttackRow, ref startAttackCol, ref endAttackCol, size);

                            for (int row = startAttackRow; row <= endAttackRow; row++)
                            {
                                for (int col = startAttackCol; col <= endAttackCol; col++)
                                {
                                    if (field[row, col] == "<")
                                    {
                                        firstPlayerShipsCount--;
                                        sunkShipsCount++;
                                    }
                                    else if (field[row, col] == ">")
                                    {
                                        secondPlayerShipsCount--;
                                        sunkShipsCount++;
                                    }

                                    field[row, col] = "X";
                                }
                            }

                            break;
                    }

                    field[attackRow, attackCol] = "X";
                }
            }

            if (secondPlayerShipsCount == 0)
            {
                Console.WriteLine($"Player One has won the game! {sunkShipsCount} ships have been sunk in the battle.");
            }
            else if (firstPlayerShipsCount == 0)
            {
                Console.WriteLine($"Player Two has won the game! {sunkShipsCount} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
            }
        }

        private static bool IsInside(int attackRow, int attackCol, int size)
        {
            if (attackRow >= 0 && attackRow < size
                && attackCol >= 0 && attackCol < size)
            {
                return true;
            }

            return false;
        }

        private static void MakeItValid(ref int startAttackRow, ref int endAttackRow, ref int startAttackCol, ref int endAttackCol, int size)
        {
            if (startAttackRow < 0)
                startAttackRow = 0;
            if (endAttackRow >= size)
                endAttackRow = size - 1;
            if (startAttackCol < 0)
                startAttackCol = 0;
            if (endAttackCol >= size)
                endAttackCol = size - 1;
        }
    }
}
