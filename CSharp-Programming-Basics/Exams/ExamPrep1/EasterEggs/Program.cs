using System;

namespace EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paintedEggsQuantity = int.Parse(Console.ReadLine());
            int redEggsCount = 0;
            int orangeEggsCount = 0;
            int blueEggsCount = 0;
            int greenEggsCount = 0;
            int maxEggsCount = 0;
            string maxEggsColor = "";

            for (int egg = 1; egg <= paintedEggsQuantity; egg++)
            {
                string eggsColor = Console.ReadLine();

                switch (eggsColor)
                {
                    case "red":
                        redEggsCount++;
                        if (redEggsCount > maxEggsCount)
                        {
                            maxEggsCount = redEggsCount;
                            maxEggsColor = "red";
                        }
                        break;
                    case "orange":
                        orangeEggsCount++;
                        if (orangeEggsCount > maxEggsCount)
                        {
                            maxEggsCount = orangeEggsCount;
                            maxEggsColor = "orange";
                        }
                        break;
                    case "blue":
                        blueEggsCount++;
                        if (blueEggsCount > maxEggsCount)
                        {
                            maxEggsCount = blueEggsCount;
                            maxEggsColor = "blue";
                        }
                        break;
                    case "green":
                        greenEggsCount++;
                        if (greenEggsCount > maxEggsCount)
                        {
                            maxEggsCount = greenEggsCount;
                            maxEggsColor = "green";
                        }
                        break;
                }
            }

            Console.WriteLine($"Red eggs: {redEggsCount}");
            Console.WriteLine($"Orange eggs: {orangeEggsCount}");
            Console.WriteLine($"Blue eggs: {blueEggsCount}");
            Console.WriteLine($"Green eggs: {greenEggsCount}");
            Console.WriteLine($"Max eggs: {maxEggsCount} -> {maxEggsColor}");
        }
    }
}
