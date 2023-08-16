using System;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int totalPieces = width * length;
            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int pieces = int.Parse(command);
                totalPieces -= pieces;
                if (totalPieces < 0)
                {
                    isValid = false;
                    break;
                }
                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"{totalPieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");
            }
        }
    }
}
