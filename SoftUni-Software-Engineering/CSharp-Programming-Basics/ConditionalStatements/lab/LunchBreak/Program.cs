using System;

namespace LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serialsName = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int lunchBreakDuration = int.Parse(Console.ReadLine());

            double lunchBreakTime = lunchBreakDuration / 8.0;
            double restTime = lunchBreakDuration / 4.0;
            double timeLeft = lunchBreakDuration - lunchBreakTime - restTime;
            double leftoverTime = Math.Ceiling(Math.Abs(timeLeft - episodeDuration));

            if (timeLeft >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {serialsName} and left with {leftoverTime} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {serialsName}, you need {leftoverTime} more minutes.");
            }
        }
    }
}
