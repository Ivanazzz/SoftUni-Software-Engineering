using System;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badGradesCount = int.Parse(Console.ReadLine());
            string lastProblem = "";
            int numberOfProblems = 0;
            int counter = 0;
            bool isValid = true;
            double averageGrade = 0;

            string problemsName = Console.ReadLine();

            while (problemsName != "Enough")
            {
                numberOfProblems++;
                lastProblem = problemsName;

                int grade = int.Parse(Console.ReadLine());

                averageGrade += grade;

                if (grade <= 4)
                {
                    counter++;
                    if (counter == badGradesCount)
                    {
                        isValid = false;
                        Console.WriteLine($"You need a break, {counter} poor grades.");
                        break;
                    }
                }
                problemsName = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"Average score: {(averageGrade * 1.00 / numberOfProblems):F2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
