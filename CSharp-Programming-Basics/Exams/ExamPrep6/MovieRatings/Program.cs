using System;

namespace MovieRatings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moviesCount = int.Parse(Console.ReadLine());

            double highestRating = 0;
            double lowestRating = 11;
            double averageRating = 0;
            string highestRatingMovieName = "";
            string lowestRatingMovieName = "";

            for (int movie = 1; movie <= moviesCount; movie++)
            {
                string moviesName = Console.ReadLine();
                double moviesRating = double.Parse(Console.ReadLine());

                averageRating += moviesRating;
                if (moviesRating > highestRating)
                {
                    highestRating = moviesRating;
                    highestRatingMovieName = moviesName;
                }
                if (moviesRating < lowestRating)
                {
                    lowestRating = moviesRating;
                    lowestRatingMovieName = moviesName;
                }
            }
            averageRating /= moviesCount;

            Console.WriteLine($"{highestRatingMovieName} is with highest rating: {highestRating:F1}");
            Console.WriteLine($"{lowestRatingMovieName} is with lowest rating: {lowestRating:F1}");
            Console.WriteLine($"Average rating: {averageRating:F1}");
        }
    }
}
