using System;

namespace RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsets = 0;
            int trashedMouses = 0;
            int trashedKeyboards = 0;
            int trashedDisplays = 0;

            for (int game = 1; game <= lostGamesCount; game++)
            {
                if(game % 3 == 0 && game % 2 == 0)
                {
                    trashedHeadsets++;
                    trashedMouses++;
                    trashedKeyboards++;
                    if(trashedKeyboards % 2 == 0)
                    {
                        trashedDisplays++;
                    }
                }
                else if(game % 3 == 0)
                {
                    trashedMouses++;
                }
                else if(game % 2 == 0)
                {
                    trashedHeadsets++;
                }
            }

            double totalPrice = (trashedHeadsets * headsetPrice) + (trashedMouses * mousePrice) + 
                (trashedKeyboards * keyboardPrice) + (trashedDisplays * displayPrice);

            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");
        }
    }
}
