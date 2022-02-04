using System;

namespace ClockPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    for (int second = 0; second < 60; second++)
                    {
                        Console.WriteLine($"{hour} : {minute} : {second}");
                    }
                }
            }
        }
    }
}
