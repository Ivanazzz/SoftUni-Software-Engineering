using System;

namespace TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string dayType = Console.ReadLine();
            double taxiPrice = 0;
            double busPrice = 0;
            double trainPrice = 0;
            double minPrice = 0;

            if (kilometers > 0)
            {
                if (dayType == "day")
                {
                    taxiPrice = kilometers * 0.79 + 0.70;
                    minPrice = taxiPrice;
                }
                else
                {
                    taxiPrice = kilometers * 0.90 + 0.70;
                    minPrice = taxiPrice;
                }
            }
            if (kilometers >= 20)
            {
                busPrice = kilometers * 0.09;
                if (busPrice < minPrice)
                {
                    minPrice = busPrice;
                }
            }
            if (kilometers >= 100)
            {
                trainPrice = kilometers * 0.06;
                if (trainPrice < minPrice)
                {
                    minPrice = trainPrice;
                }
            }

            Console.WriteLine($"{minPrice:F2}");
        }
    }
}
