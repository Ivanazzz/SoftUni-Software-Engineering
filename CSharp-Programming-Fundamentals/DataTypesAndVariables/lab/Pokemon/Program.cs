using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int startingPower = pokePower;
            int countOfPokedTargets = 0;

            while (pokePower >= distanceBetweenTargets)
            {
                pokePower -= distanceBetweenTargets;
                countOfPokedTargets++;
                if((startingPower * 0.5 == pokePower) && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(countOfPokedTargets);
        }   
    }
}
