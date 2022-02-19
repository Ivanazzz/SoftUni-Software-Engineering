using System;

namespace SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double trunkCapacity = double.Parse(Console.ReadLine());
            int suitcasesCount = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    break;
                }
                double suitcaseVolume = double.Parse(command);
                suitcasesCount++;

                if (suitcasesCount % 3 == 0)
                {
                    suitcaseVolume += suitcaseVolume * 0.1;
                }

                if (suitcaseVolume > trunkCapacity)
                {
                    Console.WriteLine("No more space!");
                    suitcasesCount--;
                    break;
                }
                else
                {
                    trunkCapacity -= suitcaseVolume;
                }
            }

            Console.WriteLine($"Statistic: {suitcasesCount} suitcases loaded.");
        }
    }
}
