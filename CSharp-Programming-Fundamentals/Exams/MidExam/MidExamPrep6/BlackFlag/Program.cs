using System;

namespace BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());   
            int dailyPlunder = int.Parse(Console.ReadLine());   
            double expectedPlunder = double.Parse(Console.ReadLine());

            double additionalPlunder = dailyPlunder * 0.5;
            double totalPlunder = 0;
            for (int day = 1; day <= days; day++)
            {
                totalPlunder += dailyPlunder;
                if (day % 3 == 0)
                {
                    totalPlunder += additionalPlunder;
                }    
                if (day % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double plunderPercentage = (totalPlunder / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {plunderPercentage:f2}% of the plunder.");
            }
        }
    }
}
