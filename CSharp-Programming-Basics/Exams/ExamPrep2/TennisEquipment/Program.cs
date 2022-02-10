using System;

namespace TennisEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tennisRacketPrice = double.Parse(Console.ReadLine());
            int tennisRacketCount = int.Parse(Console.ReadLine());
            int pairsOfSneakersCount = int.Parse(Console.ReadLine());

            double pairsOfSneakersPrice = tennisRacketPrice / 6;
            double tennisRacketTotalPrice = tennisRacketCount * tennisRacketPrice;
            double pairsOfSneakersTotalPrice = pairsOfSneakersCount * pairsOfSneakersPrice;
            double anotherEquipmentPrice = (tennisRacketTotalPrice + pairsOfSneakersTotalPrice) * 0.2;
            double totalPrice = tennisRacketTotalPrice + pairsOfSneakersTotalPrice + anotherEquipmentPrice;
            double sponsorsPrice = totalPrice * 7 / 8;
            double playersPrice = totalPrice / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(playersPrice)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsPrice)}");
        }
    }
}
