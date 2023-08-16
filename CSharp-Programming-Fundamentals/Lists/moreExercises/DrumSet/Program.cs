using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> qualityOfEachDrumInTheDrumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> qualityOfEachDrumInTheDrumSetCopy = qualityOfEachDrumInTheDrumSet.ToList();

            string command = Console.ReadLine();
            while(command != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < qualityOfEachDrumInTheDrumSetCopy.Count; i++)
                {
                    if(qualityOfEachDrumInTheDrumSetCopy[i] > 0)
                    {
                        qualityOfEachDrumInTheDrumSetCopy[i] -= hitPower;
                        if (qualityOfEachDrumInTheDrumSetCopy[i] <= 0)
                        {
                            int priceForDrum = qualityOfEachDrumInTheDrumSet[i] * 3;

                            if (priceForDrum <= savings)
                            {
                                savings -= priceForDrum;
                                qualityOfEachDrumInTheDrumSetCopy[i] = qualityOfEachDrumInTheDrumSet[i];
                            }
                            else
                            {
                                qualityOfEachDrumInTheDrumSetCopy[i] = 0;
                            }
                        }
                    }
                }
            
                command = Console.ReadLine();
            }

            qualityOfEachDrumInTheDrumSetCopy.RemoveAll(x => x == 0);
            Console.WriteLine(string.Join(" ", qualityOfEachDrumInTheDrumSetCopy));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
