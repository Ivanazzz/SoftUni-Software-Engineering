using System;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] bakery = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = rowData[col];

                    if (bakery[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int neededMoney = 50;
            int money = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                bakery[playerRow, playerCol] = '-';

                switch (direction)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                }

                if (IsOutside(playerRow, playerCol, size))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                Move(ref playerRow, ref playerCol, ref money, size, bakery);

                if (money >= neededMoney)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");
            PrintBakery(size, bakery);
        }

        private static bool IsOutside(int playerRow, int playerCol, int size)
        {
            if (playerRow < 0 || playerRow >= size
                || playerCol < 0 || playerCol >= size)
            {
                return true;
            }

            return false;
        }

        private static void Move(ref int playerRow, ref int playerCol, ref int money, int size, char[,] bakery)
        {
            if (char.IsDigit(bakery[playerRow, playerCol]))
            {
                money += bakery[playerRow, playerCol] - '0';
            }
            else if (bakery[playerRow, playerCol] == 'O')
            {
                bakery[playerRow, playerCol] = '-';

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (bakery[row, col] == 'O')
                        {
                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }
            }

            bakery[playerRow, playerCol] = 'S';
        }

        private static void PrintBakery(int size, char[,] bakery)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
