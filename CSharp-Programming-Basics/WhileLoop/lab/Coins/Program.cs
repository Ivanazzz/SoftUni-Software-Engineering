using System;

namespace Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            int coins = 0;

            while (change != 0)
            {
                change = Math.Round(change, 2);

                if (change >= 2)
                {
                    change -= 2;
                    coins++;
                }
                else if (change >= 1)
                {
                    change -= 1;
                    coins++;
                }
                else if (change >= 0.5)
                {
                    change -= 0.5;
                    coins++;
                }
                else if (change >= 0.2)
                {
                    change -= 0.2;
                    coins++;
                }
                else if (change >= 0.1)
                {
                    change -= 0.1;
                    coins++;
                }
                else if (change >= 0.05)
                {
                    change -= 0.05;
                    coins++;
                }
                else if (change >= 0.02)
                {
                    change -= 0.02;
                    coins++;
                }
                else if (change >= 0.01)
                {
                    change -= 0.01;
                    coins++;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
