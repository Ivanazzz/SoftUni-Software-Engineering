using System;

namespace Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playersName = Console.ReadLine();
            int currentPoints = 301;
            int successfulShots = 0;
            int unsuccessfulShots = 0;
            bool isValid = false;

            string pointsType = Console.ReadLine();

            while (pointsType != "Retire")
            {
                int points = int.Parse(Console.ReadLine());

                if (pointsType == "Single")
                {
                    if (currentPoints < points)
                    {
                        unsuccessfulShots++;
                    }
                    else
                    {
                        successfulShots++;
                        currentPoints -= points;
                    }
                }
                else if (pointsType == "Double")
                {
                    if (currentPoints < points * 2)
                    {
                        unsuccessfulShots++;
                    }
                    else
                    {
                        successfulShots++;
                        currentPoints -= points * 2;
                    }
                }
                else if (pointsType == "Triple")
                {
                    if (currentPoints < points * 3)
                    {
                        unsuccessfulShots++;
                    }
                    else
                    {
                        successfulShots++;
                        currentPoints -= points * 3;
                    }
                }

                if (currentPoints == 0)
                {
                    isValid = true;
                    break;
                }

                pointsType = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"{playersName} won the leg with {successfulShots} shots.");
            }
            else
            {
                Console.WriteLine($"{playersName} retired after {unsuccessfulShots} unsuccessful shots.");
            }
        }
    }
}
