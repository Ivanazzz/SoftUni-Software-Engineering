using System;

namespace Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOf1lvCoins = int.Parse(Console.ReadLine());
            int numberOf2lvCoins = int.Parse(Console.ReadLine());
            int numberOf5lvCoins = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int x = 0; x <= numberOf1lvCoins; x++)
            {
                for (int y = 0; y <= numberOf2lvCoins; y++)
                {
                    for (int z = 0; z <= numberOf5lvCoins; z++)
                    {
                        if (((x * 1) + (y * 2) + (z * 5)) == sum)
                        {
                            Console.WriteLine($"{x} * 1 lv. + {y} * 2 lv. + {z} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
