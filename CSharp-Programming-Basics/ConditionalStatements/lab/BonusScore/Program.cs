using System;

namespace BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentPoints = int.Parse(Console.ReadLine());
            double bonusPoints = 0.0;

            if (currentPoints <= 100)
            {
                bonusPoints = bonusPoints + 5;
            }
            else if (currentPoints > 100 && currentPoints <= 1000)
            {
                bonusPoints = currentPoints * 0.2;
            }
            else
            {
                bonusPoints = currentPoints * 0.1;
            }

            if (currentPoints % 2 == 0)
            {
                bonusPoints += 1;
            }

            if (currentPoints % 10 == 5)
            {
                bonusPoints += 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(currentPoints + bonusPoints);
        }
    }
}
