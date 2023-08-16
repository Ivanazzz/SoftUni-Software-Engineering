using System;
using System.Linq;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] passengersInEachWagon = new int[numberOfWagons];

            for (int i = 0; i < passengersInEachWagon.Length; i++)
            {
                passengersInEachWagon[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', passengersInEachWagon));
            Console.WriteLine(passengersInEachWagon.Sum());
        }
    }
}
