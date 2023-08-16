using System;

namespace Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ballsCount = int.Parse(Console.ReadLine());

            int redBallsCount = 0;
            int orangeBallsCount = 0;
            int yellowBallsCount = 0;
            int whiteBallsCount = 0;
            int blackBallsCount = 0;
            int otherBallsCount = 0;
            double points = 0;

            for (int ball = 1; ball <= ballsCount; ball++)
            {
                string color = Console.ReadLine();
                
                switch (color)
                {
                    case "red":
                        points += 5;
                        redBallsCount++;
                        break;
                    case "orange":
                        points += 10;
                        orangeBallsCount++;
                        break;
                    case "yellow":
                        points += 15;
                        yellowBallsCount++;
                        break;
                    case "white":
                        points += 20;
                        whiteBallsCount++;
                        break;
                    case "black":
                        points = Math.Floor(points / 2);
                        blackBallsCount++;
                        break;
                    default:
                        otherBallsCount++;
                        break;

                }
            }

            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Red balls: {redBallsCount}");
            Console.WriteLine($"Orange balls: {orangeBallsCount}");
            Console.WriteLine($"Yellow balls: {yellowBallsCount}");
            Console.WriteLine($"White balls: {whiteBallsCount}");
            Console.WriteLine($"Other colors picked: {otherBallsCount}");
            Console.WriteLine($"Divides from black balls: {blackBallsCount}");
        }
    }
}
