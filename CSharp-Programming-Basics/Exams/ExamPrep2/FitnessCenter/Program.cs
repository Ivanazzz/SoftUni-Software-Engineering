using System;

namespace FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clientsCount = int.Parse(Console.ReadLine());

            int backCount = 0;
            int chestCount = 0;
            int legsCount = 0;
            int absCount = 0;
            int proteinShakeCount = 0;
            int proteinBarCount = 0;

            for (int client = 1; client <= clientsCount; client++)
            {
                string activity = Console.ReadLine();

                switch (activity)
                {
                    case "Back":
                        backCount++;
                        break;
                    case "Chest":
                        chestCount++;
                        break;
                    case "Legs":
                        legsCount++;
                        break;
                    case "Abs":
                        absCount++;
                        break;
                    case "Protein shake":
                        proteinShakeCount++;
                        break;
                    case "Protein bar":
                        proteinBarCount++;
                        break;
                }
            }

            int trainingPeople = backCount + chestCount + legsCount + absCount;
            int buyingPeople = proteinBarCount + proteinShakeCount;
            double trainingPeoplePercentage = (trainingPeople * 1.00 / clientsCount) * 100;
            double buyingPeoplePercentage = (buyingPeople * 1.00 / clientsCount) * 100;

            Console.WriteLine($"{backCount} - back");
            Console.WriteLine($"{chestCount} - chest");
            Console.WriteLine($"{legsCount} - legs");
            Console.WriteLine($"{absCount} - abs");
            Console.WriteLine($"{proteinShakeCount} - protein shake");
            Console.WriteLine($"{proteinBarCount} - protein bar");
            Console.WriteLine($"{trainingPeoplePercentage:F2}% - work out");
            Console.WriteLine($"{buyingPeoplePercentage:F2}% - protein");
        }
    }
}
