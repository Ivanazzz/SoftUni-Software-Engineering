using System;

namespace Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bottlesOfCleaner = int.Parse(Console.ReadLine());

            int cleanerInMililiters = bottlesOfCleaner * 750;
            int counter = 0;
            int dishes = 0;
            int pots = 0;
            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "End")
            {
                counter++;
                int totalDishesCount = int.Parse(command);

                if (counter % 3 == 0)
                {
                    cleanerInMililiters -= totalDishesCount * 15;
                    pots += totalDishesCount;
                }
                else
                {
                    cleanerInMililiters -= totalDishesCount * 5;
                    dishes += totalDishesCount;
                }

                if (cleanerInMililiters < 0)
                {
                    isValid = false;
                    break;
                }
                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {cleanerInMililiters} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(cleanerInMililiters)} ml. more necessary!");
            }
        }
    }
}
