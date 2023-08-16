using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            PrintGradeType(grade);
        }

        static void PrintGradeType(double grade)
        {
            string gradeType = "";
            if(grade >= 2.00 && grade < 3.00)
            {
                gradeType = "Fail";
            }
            else if(grade >= 3.00 && grade < 3.50)
            {
                gradeType = "Poor";
            }
            else if (grade >= 3.50 && grade < 4.50)
            {
                gradeType = "Good";
            }
            else if (grade >= 4.50 && grade < 5.50)
            {
                gradeType = "Very good";
            }
            else if (grade >= 5.50 && grade <= 6.00)
            {
                gradeType = "Excellent";
            }

            Console.WriteLine(gradeType);
        }
    }
}
