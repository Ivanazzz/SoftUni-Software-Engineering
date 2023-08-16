using System;
using System.Collections.Generic;

namespace PawnWars
{
    internal class Program
    {
        const int Size = 8;

        static void Main(string[] args)
        {
            char[,] chessboard = new char[Size, Size];

            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;

            for (int row = 0; row < Size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < Size; col++)
                {
                    chessboard[row, col] = rowData[col];

                    if (chessboard[row, col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }
                    else if (chessboard[row, col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                }
            }

            bool whiteTurn = true;

            while (true)
            {
                if (whiteTurn)
                {
                    chessboard[whitePawnRow, whitePawnCol] = '-';
                    MoveWhitePawn(ref whitePawnRow, ref whitePawnCol, whitePawnRow - 1, blackPawnRow, blackPawnCol, chessboard);
                }
                else
                {
                    chessboard[blackPawnRow, blackPawnCol] = '-';
                    MoveBlackPawn(whitePawnRow, whitePawnCol, ref blackPawnRow, ref blackPawnCol, blackPawnRow + 1, chessboard);
                }

                whiteTurn = !whiteTurn;
            }
        }

        private static void MoveWhitePawn(ref int whitePawnRow, ref int whitePawnCol, int newWhitePawnRow, int blackPawnRow, int blackPawnCol, char[,] chessboard)
        {
            if (IsOutside(newWhitePawnRow))
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whitePawnCol + 97)}{8 - whitePawnRow}.");
                Environment.Exit(0);
            }

            whitePawnRow = newWhitePawnRow;
            if (whitePawnRow == blackPawnRow 
                && (whitePawnCol - 1 == blackPawnCol || whitePawnCol + 1 == blackPawnCol))
            {
                chessboard[blackPawnRow, blackPawnCol] = 'w';
                whitePawnCol = blackPawnCol;

                Console.WriteLine($"Game over! White capture on {(char)(whitePawnCol + 97)}{8 - whitePawnRow}.");
                Environment.Exit(0);
            }
        }

        private static void MoveBlackPawn(int whitePawnRow, int whitePawnCol, ref int blackPawnRow, ref int blackPawnCol, int newBlackPawnRow, char[,] chessboard)
        {
            if (IsOutside(newBlackPawnRow))
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackPawnCol + 97)}{8 - blackPawnRow}.");
                Environment.Exit(0);
            }

            blackPawnRow = newBlackPawnRow;
            if (blackPawnRow == whitePawnRow
                && (blackPawnCol - 1 == whitePawnCol || blackPawnCol + 1 == whitePawnCol))
            {
                chessboard[whitePawnRow, whitePawnCol] = 'b';
                blackPawnCol = whitePawnCol;

                Console.WriteLine($"Game over! Black capture on {(char)(blackPawnCol + 97)}{8 - blackPawnRow}.");
                Environment.Exit(0);
            }
        }

        private static bool IsOutside(int playerRow)
        {
            if (playerRow < 0 || playerRow >= Size)
            {
                return true;
            }

            return false;
        }
    }
}
