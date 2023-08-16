using System;

namespace HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int requiredHeight = int.Parse(Console.ReadLine());

            int targetHeight = requiredHeight - 30;
            int totalAttempts = 0;
            bool isValid = false;
            bool isPassed = true;

            while (true)
            {
                int currentHeight = int.Parse(Console.ReadLine());
                totalAttempts++;

                if (currentHeight > targetHeight)
                {
                    if (targetHeight == requiredHeight)
                    {
                        isValid = true;
                        break;
                    }
                    targetHeight += 5;
                }
                else
                {
                    int unsuccessfulAttempts = 0;

                    while (true)
                    {
                        unsuccessfulAttempts++;
                        if (unsuccessfulAttempts >= 3)
                        {

                            isPassed = false;
                            break;
                        }
                        currentHeight = int.Parse(Console.ReadLine());
                        totalAttempts++;
                        if (currentHeight > targetHeight)
                        {
                            targetHeight += 5;
                            break;
                        }
                    }
                }

                if (!isPassed)
                {
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {requiredHeight}cm after {totalAttempts} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir failed at {targetHeight}cm after {totalAttempts} jumps.");
            }
        }
    }
}
