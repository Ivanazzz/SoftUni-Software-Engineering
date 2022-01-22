using System;

namespace HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double houseHeight = double.Parse(Console.ReadLine());
            double sideWallLenght = double.Parse(Console.ReadLine());
            double triangleRoofWallHeight = double.Parse(Console.ReadLine());

            double sideWallArea = houseHeight * sideWallLenght;
            double windowArea = 1.5 * 1.5;
            double sideWallTotalArea = (2 * sideWallArea) - (2 * windowArea);
            double backWallArea = houseHeight * houseHeight;
            double doorArea = 1.2 * 2;
            double frontAndBackWallTotalArea = (2 * backWallArea) - doorArea;
            double wallsTotalArea = sideWallTotalArea + frontAndBackWallTotalArea;
            double greenPaintLiters = wallsTotalArea / 3.4;

            double rectangleRoofWallArea = 2 * (houseHeight * sideWallLenght);
            double triangleRoofWallArea = 2 * (houseHeight * triangleRoofWallHeight / 2);
            double rooftopTotalArea = rectangleRoofWallArea + triangleRoofWallArea;
            double redPaintLiters = rooftopTotalArea / 4.3;

            Console.WriteLine($"{greenPaintLiters:F2}");
            Console.WriteLine($"{redPaintLiters:F2}");
        }
    }
}
