using System;

namespace Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floorsCount = int.Parse(Console.ReadLine());
            int numberOfRoomsPerFloor = int.Parse(Console.ReadLine());

            char roomType = ' ';

            for (int floor = floorsCount; floor >= 1; floor--)
            {
                for (int room = 0; room < numberOfRoomsPerFloor; room++)
                {
                    if (floor == floorsCount)
                    {
                        roomType = 'L';
                    }
                    else
                    {
                        if (floor % 2 != 0)
                        {
                            roomType = 'A';
                        }
                        else if (floor % 2 == 0)
                        {
                            roomType = 'O';
                        }
                    }

                    Console.Write($"{roomType}{floor}{room} ");
                }

                Console.WriteLine();
            }
        }
    }
}
