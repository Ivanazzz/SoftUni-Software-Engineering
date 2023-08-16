using System;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int mazeSize = int.Parse(Console.ReadLine());

            char[][] maze = new char[mazeSize][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < mazeSize; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                maze[row] = rowData;

                for (int col = 0; col < rowData.Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;

                        break;
                    }
                }
            }

            while (true)
            {
                string[] enemySpawn = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = enemySpawn[0];
                int enemyRow = int.Parse(enemySpawn[1]);
                int enemyCol = int.Parse(enemySpawn[2]);

                maze[enemyRow][enemyCol] = 'B';
                marioLives--;

                switch (direction)
                {
                    case "W":
                        Move(ref marioRow, ref marioCol, marioRow - 1, marioCol, ref marioLives, mazeSize, maze);
                        break;
                    case "S":
                        Move(ref marioRow, ref marioCol, marioRow + 1, marioCol, ref marioLives, mazeSize, maze);
                        break;
                    case "A":
                        Move(ref marioRow, ref marioCol, marioRow, marioCol - 1, ref marioLives, mazeSize, maze);
                        break;
                    case "D":
                        Move(ref marioRow, ref marioCol, marioRow, marioCol + 1, ref marioLives, mazeSize, maze);
                        break;
                }
            }
        }

        private static void Move(ref int marioRow, ref int marioCol, int newMarioRow, int newMarioCol, ref int marioLives, int mazeSize, char[][] maze)
        {
            if (IsInside(newMarioRow, newMarioCol, mazeSize, maze))
            {
                maze[marioRow][marioCol] = '-';
                marioRow = newMarioRow;
                marioCol = newMarioCol;

                if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    PrintMaze(maze);

                    Environment.Exit(0);
                }
                else if (maze[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                }

                IsMarioOutOfLives(marioLives, marioRow, marioCol, mazeSize, maze);
                maze[marioRow][marioCol] = 'M';
            }
        }

        private static bool IsInside(int marioRow, int marioCol, int mazeSize, char[][] maze)
        {
            if (marioRow >= 0 && marioRow < mazeSize 
                 && marioCol >= 0 && marioCol < maze[marioRow].Length)
            {
                return true;
            }

            return false;
        }

        private static void IsMarioOutOfLives(int marioLives, int marioRow, int marioCol, int mazeSize, char[][] maze)
        {
            if (marioLives <= 0)
            {
                maze[marioRow][marioCol] = 'X';
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                PrintMaze(maze);

                Environment.Exit(0);
            }
        }

        public static void PrintMaze(char[][] maze)
        {
            foreach (char[] row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
