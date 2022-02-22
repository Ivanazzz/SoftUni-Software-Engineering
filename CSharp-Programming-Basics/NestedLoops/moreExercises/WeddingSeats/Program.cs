using System;

namespace WeddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int oddRowsSeats = int.Parse(Console.ReadLine());

            char startSector = 'A';
            char startSeat = 'a';
            int totalSeats = 0;

            for (int sector = (int)startSector; sector <= (int)lastSector; sector++)
            {
                for (int row = 1; row <= rows; row++)
                {
                    if (row % 2 != 0)
                    {
                        for (int seat = (int)startSeat; seat <= (int)startSeat + oddRowsSeats - 1; seat++)
                        {
                            totalSeats++;
                            Console.WriteLine($"{(char)sector}{row}{(char)seat}");
                        }
                    }
                    else
                    {
                        for (int seat = (int)startSeat; seat <= (int)startSeat + (oddRowsSeats - 1) + 2; seat++)
                        {
                            totalSeats++;
                            Console.WriteLine($"{(char)sector}{row}{(char)seat}");
                        }
                    }
                }

                rows++;
            }

            Console.WriteLine(totalSeats);
        }
    }
}
