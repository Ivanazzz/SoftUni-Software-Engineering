using System;

namespace CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstRectangleSide = int.Parse(Console.ReadLine());
            int secondRectangleSide = int.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(firstRectangleSide, secondRectangleSide));
        }

        static int RectangleArea(int firstRectangleSide, int secondRectangleSide)
        {
            return firstRectangleSide * secondRectangleSide;
        }
    }
}
