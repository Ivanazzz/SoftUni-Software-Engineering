using System;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] territory = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = rowData[col];

                    if (territory[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int neededFlowers = 5;
            int pollinatedFlowers = 0;
            bool isLost = false;

            while (!isLost)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                territory[beeRow, beeCol] = '.';

                switch (command)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                Move(ref beeRow, ref beeCol, ref pollinatedFlowers, command, ref isLost, size, territory);
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers >= neededFlowers)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {neededFlowers - pollinatedFlowers} flowers more");
            }

            PrintTerritory(size, territory);
        }

        private static void Move(ref int beeRow, ref int beeCol, ref int pollinatedFlowers, string command, ref bool isLost, int size, char[,] territory)
        {
            if (IsOutside(beeRow, beeCol, size, ref isLost))
            {
                return;
            }

            if (territory[beeRow, beeCol] == 'f')
            {
                pollinatedFlowers++;
            }
            else if (territory[beeRow, beeCol] == 'O')
            {
                territory[beeRow, beeCol] = '.';

                switch (command)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                Move(ref beeRow, ref beeCol, ref pollinatedFlowers, command, ref isLost, size, territory);
            }

            territory[beeRow, beeCol] = 'B';
        }

        private static bool IsOutside(int beeRow, int beeCol, int size, ref bool isLost)
        {
            if (beeRow < 0 || beeRow >= size
                || beeCol < 0 || beeCol >= size)
            {
                isLost = true;
                return true;
            }

            return false;
        }

        private static void PrintTerritory(int size, char[,] territory)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
