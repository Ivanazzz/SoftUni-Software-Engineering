using System;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beerKegsCount = int.Parse(Console.ReadLine());
            string biggestBeerKeg = "";
            double biggestBeerKegVolume = 0;

            for (int i = 0; i < beerKegsCount; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if(volume > biggestBeerKegVolume)
                {
                    biggestBeerKegVolume = volume;
                    biggestBeerKeg = model;
                }
            }

            Console.WriteLine(biggestBeerKeg);
        }
    }
}
