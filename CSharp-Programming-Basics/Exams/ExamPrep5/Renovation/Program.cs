using System;

namespace Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            int wallAreaNotPaintedPercentage = int.Parse(Console.ReadLine());

            double totalSurface = wallHeight * wallWidth * 4;
            totalSurface -= totalSurface * wallAreaNotPaintedPercentage * 1.00 / 100;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Tired!")
                {
                    Console.WriteLine($"{totalSurface} quadratic m left.");
                    return;
                }
                int paintLiters = int.Parse(command);
                totalSurface -= paintLiters;
                if (totalSurface == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                }
                else if (totalSurface < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(totalSurface)} l paint left!");
                    return;
                }
            }
        }
    }
}
