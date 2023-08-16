using System;

namespace LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Points coordinates of the first line
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            // Points coordinates of the second line
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            LongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        private static void LongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double firstLineLength = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double secondLineLength = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));

            if(firstLineLength >= secondLineLength)
            {
                ClosestPointToCenter(x1, y1, x2, y2);
                return;
            }

            ClosestPointToCenter(x3, y3, x4, y4);
        }

        private static void ClosestPointToCenter(double xOfFirstPoint, double yOfFirstPoint, double xOfSecondPoint, double yOfSecondPoint)
        {
            double distanceToCenterOfFirstPoint = Math.Sqrt(Math.Pow(xOfFirstPoint, 2) + Math.Pow(yOfFirstPoint, 2));
            double distanceToCenterOfSecondPoint = Math.Sqrt(Math.Pow(xOfSecondPoint, 2) + Math.Pow(yOfSecondPoint, 2));

            if (distanceToCenterOfFirstPoint <= distanceToCenterOfSecondPoint)
            {
                Console.WriteLine($"({xOfFirstPoint}, {yOfFirstPoint})({xOfSecondPoint}, {yOfSecondPoint})");
            }
            else
            {
                Console.WriteLine($"({xOfSecondPoint}, {yOfSecondPoint})({xOfFirstPoint}, {yOfFirstPoint})");
            }
        }
    }
}
