using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];
            int startRowIndex = 0;
            int startColIndex = 0;
            int totalCoalsCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] chars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => char.Parse(n))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = chars[col];

                    if (chars[col] == 's')
                    {
                        startRowIndex = row;
                        startColIndex = col;
                    }
                    else if (chars[col] == 'c')
                    {
                        totalCoalsCount++;
                    }
                }
            }

            int coalsFound = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                Move(i, ref startRowIndex, ref startColIndex, ref coalsFound, commands, field);

                if (coalsFound == totalCoalsCount)
                {
                    Console.WriteLine($"You collected all coals! ({startRowIndex}, {startColIndex})");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"{totalCoalsCount - coalsFound} coals left. ({startRowIndex}, {startColIndex})");
        }

        private static void Move(int i, ref int startRowIndex, ref int startColIndex, ref int coalsFound, 
            string[] commands, char[,] field)
        {
            switch (commands[i])
            {
                case "left":
                    startColIndex--;
                    if (startColIndex < 0)
                    {
                        startColIndex = 0;
                    }
                    break;
                case "right":
                    startColIndex++;
                    if (startColIndex > field.GetLength(1) - 1)
                    {
                        startColIndex = field.GetLength(1) - 1;
                    }
                    break;
                case "up":
                    startRowIndex--;
                    if (startRowIndex < 0)
                    {
                        startRowIndex = 0;
                    }
                    break;
                case "down":
                    startRowIndex++;
                    if (startRowIndex > field.GetLength(0) - 1)
                    {
                        startRowIndex = field.GetLength(0) - 1;
                    }
                    break;
            }

            Action(startRowIndex, startColIndex, ref coalsFound, field);
        }

        private static void Action(int startRowIndex, int startColIndex, ref int coalsFound, char[,] field)
        {
            if (field[startRowIndex, startColIndex] == 'c')
            {
                coalsFound++;
                field[startRowIndex, startColIndex] = '*';
            }
            else if (field[startRowIndex, startColIndex] == 'e')
            {
                Console.WriteLine($"Game over! ({startRowIndex}, {startColIndex})");
                Environment.Exit(1);
            }
        }
    }
}
