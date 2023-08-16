using System;

namespace TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            int musalaPeoplesCount = 0;
            int monblanPeoplesCount = 0;
            int kilimanjaroPeoplesCount = 0;
            int k2PeoplesCount = 0;
            int everestPeoplesCount = 0;
            int totalPeople = 0;

            for (int i = 1; i <= groupsCount; i++)
            {
                int personsCountPerGroup = int.Parse(Console.ReadLine());
                totalPeople += personsCountPerGroup;

                if (personsCountPerGroup <= 5)
                {
                    musalaPeoplesCount += personsCountPerGroup;
                }
                else if (personsCountPerGroup <= 12)
                {
                    monblanPeoplesCount += personsCountPerGroup;
                }
                else if (personsCountPerGroup <= 25)
                {
                    kilimanjaroPeoplesCount += personsCountPerGroup;
                }
                else if (personsCountPerGroup <= 40)
                {
                    k2PeoplesCount += personsCountPerGroup;
                }
                else
                {
                    everestPeoplesCount += personsCountPerGroup;
                }
            }

            double musalaPercent = musalaPeoplesCount * 1.00 / totalPeople * 100;
            double monblanPercent = monblanPeoplesCount * 1.00 / totalPeople * 100;
            double kilimanjaroPercent = kilimanjaroPeoplesCount * 1.00 / totalPeople * 100;
            double k2Percent = k2PeoplesCount * 1.00 / totalPeople * 100;
            double everestPercent = everestPeoplesCount * 1.00 / totalPeople * 100;

            Console.WriteLine($"{musalaPercent:F2}%");
            Console.WriteLine($"{monblanPercent:F2}%");
            Console.WriteLine($"{kilimanjaroPercent:F2}%");
            Console.WriteLine($"{k2Percent:F2}%");
            Console.WriteLine($"{everestPercent:F2}%");
        }
    }
}
