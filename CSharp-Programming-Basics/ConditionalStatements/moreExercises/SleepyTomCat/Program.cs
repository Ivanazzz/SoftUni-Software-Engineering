using System;

namespace SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());
            int workingDays = 365 - holidays;
            int totalPlaytime = (workingDays * 63) + (holidays * 127);
            int playtimeNorm = 30000;
            int timeDifference = playtimeNorm - totalPlaytime;
            int playtimeHours = Math.Abs(timeDifference / 60);
            int playtimeMinutes = Math.Abs(timeDifference % 60);

            if (timeDifference < 0)
            {
                timeDifference = Math.Abs(timeDifference);
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{playtimeHours} hours and {playtimeMinutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{playtimeHours} hours and {playtimeMinutes} minutes less for play");
            }
        }
    }
}
