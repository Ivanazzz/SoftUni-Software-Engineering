using System;

namespace OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statuettes = rent - (rent * 0.3);
            double catering = statuettes - (statuettes * 0.15);
            double voiceover = catering / 2;
            double totalSum = rent + statuettes + catering + voiceover;

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
