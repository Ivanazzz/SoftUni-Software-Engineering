using System;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;
            int times = int.Parse(Console.ReadLine());
            int litersSum = 0;

            for (int i = 0; i < times; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if(litersSum + liters > CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    litersSum += liters;
                }
            }

            Console.WriteLine(litersSum);
        }
    }
}
