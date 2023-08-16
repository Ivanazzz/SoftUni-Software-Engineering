using System;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string trackedRaceCar = Console.ReadLine();

            string[,] raceRoute = new string[size, size];
            int carRow = 0;
            int carCol = 0;
            int kilometers = 0;

            for (int row = 0; row < size; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    raceRoute[row, col] = rowData[col];
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    raceRoute[carRow, carCol] = "C";
                    Console.WriteLine($"Racing car {trackedRaceCar} DNF.");
                    Console.WriteLine($"Distance covered {kilometers} km.");
                    PrintRaceRoute(size, raceRoute);

                    Environment.Exit(0);
                }

                switch (direction)
                {
                    case "up":
                        carRow--;
                        Move(ref carRow, ref carCol, ref kilometers, trackedRaceCar, size, raceRoute);
                        break;
                    case "down":
                        carRow++;
                        Move(ref carRow, ref carCol, ref kilometers, trackedRaceCar, size, raceRoute);
                        break;
                    case "left":
                        carCol--;
                        Move(ref carRow, ref carCol, ref kilometers, trackedRaceCar, size, raceRoute);
                        break;
                    case "right":
                        carCol++;
                        Move(ref carRow, ref carCol, ref kilometers, trackedRaceCar, size, raceRoute);
                        break;
                }
            }
        }

        private static void Move(ref int carRow, ref int carCol, ref int kilometers, string trackedRaceCar, int size, string[,] raceRoute)
        {
            kilometers += 10;

            if (raceRoute[carRow, carCol] == "T")
            {
                raceRoute[carRow, carCol] = ".";

                for (int row = 0; row < size; row++)
                {
                    bool isFound = false;

                    for (int col = 0; col < size; col++)
                    {
                        if (raceRoute[row, col] == "T")
                        {
                            carRow = row;
                            carCol = col;
                            raceRoute[carRow, carCol] = ".";
                            kilometers += 20;

                            isFound = true;
                            break;
                        }

                        if (isFound)
                        {
                            break;
                        }
                    }
                }
            }
            else if (raceRoute[carRow, carCol] == "F")
            {
                raceRoute[carRow, carCol] = "C";
                Console.WriteLine($"Racing car {trackedRaceCar} finished the stage!");
                Console.WriteLine($"Distance covered {kilometers} km.");
                PrintRaceRoute(size, raceRoute);

                Environment.Exit(0);
            }
        }

        private static void PrintRaceRoute(int size, string[,] raceRoute)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(raceRoute[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
