using System;

namespace PrimePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumFirstPair = int.Parse(Console.ReadLine());
            int startNumSecondPair = int.Parse(Console.ReadLine());
            int differenceFirstPair = int.Parse(Console.ReadLine());
            int differenceSecondPair = int.Parse(Console.ReadLine());

            int endNumFirstPair = startNumFirstPair + differenceFirstPair;
            int endNumSecondPair = startNumSecondPair + differenceSecondPair;

            for (int x = startNumFirstPair; x <= endNumFirstPair; x++)
            {
                int counter = 0;
                for (int i = 1; i <= x; i++)
                {
                    if (x % i == 0)
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    for (int y = startNumSecondPair; y <= endNumSecondPair; y++)
                    {
                        counter = 0;
                        for (int j = 1; j <= y; j++)
                        {
                            if (y % j == 0)
                            {
                                counter++;
                            }
                        }

                        if (counter == 2)
                        {
                            Console.Write($"{x}{y}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
