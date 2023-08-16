using System;

namespace CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double xOfFirstPoint = int.Parse(Console.ReadLine());
            double yOfFirstPoint = int.Parse(Console.ReadLine());
            double xOfSecondPoint = int.Parse(Console.ReadLine());
            double yOfSecondPoint = int.Parse(Console.ReadLine());

            PointClosestToCenter(xOfFirstPoint, yOfFirstPoint, xOfSecondPoint, yOfSecondPoint);
        }

        static void PointClosestToCenter(double xOfFirstPoint, double yOfFirstPoint, double xOfSecondPoint, double yOfSecondPoint)
        {
            double distanceToCenterOfFirstPoint = Math.Sqrt(Math.Pow(xOfFirstPoint, 2) + Math.Pow(yOfFirstPoint, 2));
            double distanceToCenterOfSecondPoint = Math.Sqrt(Math.Pow(xOfSecondPoint, 2) + Math.Pow(yOfSecondPoint, 2));

            if (distanceToCenterOfFirstPoint <= distanceToCenterOfSecondPoint)
            {
                Console.WriteLine($"({xOfFirstPoint}, {yOfFirstPoint})");
            }
            else
            {
                Console.WriteLine($"({xOfSecondPoint}, {yOfSecondPoint})");
            }
        }
    }
}