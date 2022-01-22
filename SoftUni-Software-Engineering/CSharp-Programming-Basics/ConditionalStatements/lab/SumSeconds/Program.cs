using System;

namespace SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seconds1 = int.Parse(Console.ReadLine());
            int seconds2 = int.Parse(Console.ReadLine());
            int seconds3 = int.Parse(Console.ReadLine());
            int totalSecondsSum = seconds1 + seconds2 + seconds3;

            int minutes = 0;
            int seconds = 0;

            minutes = totalSecondsSum / 60;
            seconds = totalSecondsSum % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
