using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CONSUMED_SPICES = 26;
            const int MINIMUM_SPICES_TO_GATHER_FROM_MINE = 100;
            const int DAILY_DECREASE_OF_MINE_YIELD = 10;

            int startYield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalSpices = 0;

            while(startYield >= MINIMUM_SPICES_TO_GATHER_FROM_MINE)
            {
                totalSpices += startYield - CONSUMED_SPICES;
                startYield -= DAILY_DECREASE_OF_MINE_YIELD; 
                days++;
                if(startYield < MINIMUM_SPICES_TO_GATHER_FROM_MINE)
                {
                    totalSpices -= CONSUMED_SPICES;
                }
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpices);
        }
    }
}
