using System;
using System.Threading;

namespace ConsoleMiniGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 10;
            int col = 30;
            int rowDirection = 0;
            int colDirection = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.DownArrow)
                    {
                        colDirection = 0;
                        rowDirection = 1;
                    }
                    else if (key == ConsoleKey.UpArrow)
                    {
                        colDirection = 0;
                        rowDirection = -1;
                    }
                    else if (key == ConsoleKey.LeftArrow)
                    {
                        colDirection = -1;
                        rowDirection = 0;
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        colDirection = 1;
                        rowDirection = 0;
                    }
                }

                Console.SetCursorPosition(col, row);
                Console.Write('@');

                col += colDirection;
                row += rowDirection;

                Thread.Sleep(100);
            }
        }
    }
}
