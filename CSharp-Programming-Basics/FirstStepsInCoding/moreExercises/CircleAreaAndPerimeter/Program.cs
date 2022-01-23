using System;

namespace CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double circleParameter = 2 * radius * Math.PI;
            double circleArea = Math.PI * radius * radius;

            Console.WriteLine($"{circleArea:F2}");
            Console.WriteLine($"{circleParameter:F2}");
        }
    }
}
