using System;

namespace TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lenghtMeters = double.Parse(Console.ReadLine());
            double widthMeters = double.Parse(Console.ReadLine());
            double lenghtCentimeters = lenghtMeters * 100;
            double widthCentimeters = widthMeters * 100;
            int hallway = 100;
            double leftoverWidth = widthCentimeters - hallway;
            double desks = Math.Floor(leftoverWidth / 70.0);
            double rows = Math.Floor(lenghtCentimeters / 120.0);
            double numberOfSeats = (desks * rows) - 3;

            Console.WriteLine(numberOfSeats);
        }
    }
}
