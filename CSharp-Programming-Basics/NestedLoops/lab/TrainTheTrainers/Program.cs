using System;

namespace TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jurysCount = int.Parse(Console.ReadLine());
            double finalAverageGrade = 0;
            int counter = 0;

            string presentationsName = Console.ReadLine();

            while (presentationsName != "Finish")
            {
                double averageGrade = 0;

                for (int jury = 1; jury <= jurysCount; jury++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    counter++;
                    averageGrade += grade;
                    finalAverageGrade += grade;
                }

                Console.WriteLine($"{presentationsName} - {(averageGrade / jurysCount):F2}.");
                presentationsName = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {(finalAverageGrade / counter):F2}.");
        }
    }
}
