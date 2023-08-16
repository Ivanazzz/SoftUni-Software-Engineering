using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            double gradeSum = 0;
            int excellentResultsCount = 0;
            int veryGoodResultsCount = 0;
            int goodResultsCount = 0;
            int badResultsCount = 0;

            for (int student = 1; student <= studentsCount; student++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 3)
                {
                    badResultsCount++;
                }
                else if (grade < 4)
                {
                    goodResultsCount++;
                }
                else if (grade < 5)
                {
                    veryGoodResultsCount++;
                }
                else if (grade <= 6)
                {
                    excellentResultsCount++;
                }

                gradeSum += grade;
            }

            double averageGrade = gradeSum / studentsCount;
            double excellentGradesPercentage = excellentResultsCount * 1.00 / studentsCount * 100;
            double veryGoodGradesPercentage = veryGoodResultsCount * 1.00 / studentsCount * 100;
            double goodGradesPercentage = goodResultsCount * 1.00 / studentsCount * 100;
            double badGradesPercentage = badResultsCount * 1.00 / studentsCount * 100;

            Console.WriteLine($"Top students: {excellentGradesPercentage:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {veryGoodGradesPercentage:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {goodGradesPercentage:F2}%");
            Console.WriteLine($"Fail: {badGradesPercentage:F2}%");
            Console.WriteLine($"Average: {averageGrade:F2}");
        }
    }
}
