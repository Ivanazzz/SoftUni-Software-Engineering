using System;

namespace SeriesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodesPerSeason = int.Parse(Console.ReadLine());
            int episodesDuration = int.Parse(Console.ReadLine());   

            double adsDuration = episodesDuration * 0.2;
            int specialEpisodesMinutes = seasons * 10;
            double totalMinutesEpisodesDuration = episodesDuration + adsDuration;
            double totalMinutesForSeries = totalMinutesEpisodesDuration * episodesPerSeason * seasons + specialEpisodesMinutes;

            Console.WriteLine($"Total time needed to watch the {seriesName} series is {Math.Floor(totalMinutesForSeries)} minutes.");
        }
    }
}
