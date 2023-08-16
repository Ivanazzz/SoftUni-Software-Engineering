using System;

namespace Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = 0;
            bool isValid = false;

            while (true)
            {
                string steps = Console.ReadLine();

                if (steps == "Going home")
                {
                    int finalSteps = int.Parse(Console.ReadLine());
                    totalSteps += finalSteps;
                    if (totalSteps >= 10000)
                    {
                        isValid = true;
                    }
                    break;
                }
                int dailySteps = int.Parse(steps);
                totalSteps += dailySteps;

                if (totalSteps >= 10000)
                {
                    isValid = true;
                    break;
                }

            }

            if (isValid)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }
        }
    }
}
