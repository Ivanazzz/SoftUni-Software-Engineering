using System;

namespace ExcursionSale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seaExcursionsCount = int.Parse(Console.ReadLine());
            int mountainExcursionsCount = int.Parse(Console.ReadLine());

            int profit = 0;
            bool isValid = false;

            while (true)
            {
                string package = Console.ReadLine();
                if (package == "Stop")
                {
                    break;
                }
                else if (package == "sea")
                {
                    if (seaExcursionsCount > 0)
                    {
                        profit += 680;
                        seaExcursionsCount--;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (package == "mountain")
                {
                    if (mountainExcursionsCount > 0)
                    {
                        profit += 499;
                        mountainExcursionsCount--;
                    }
                    else
                    {
                        continue;
                    }
                }
                
                if (seaExcursionsCount == 0 && mountainExcursionsCount == 0)
                {
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }
            Console.WriteLine($"Profit: {profit} leva.");
        }
    }
}
