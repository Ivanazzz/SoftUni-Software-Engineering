using System;

namespace BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());   
            int lectures = int.Parse(Console.ReadLine());   
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int bestStudentAttendances = 0;
            for (int student = 1; student <= students; student++)
            {
                int currentStudentAttendances = int.Parse(Console.ReadLine());
                double totalBonusPerStudent = (currentStudentAttendances * 1.0 / lectures) * (5 + additionalBonus);

                if(totalBonusPerStudent > maxBonus)
                {
                    maxBonus = totalBonusPerStudent;
                    bestStudentAttendances = currentStudentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");
        }
    }
}
