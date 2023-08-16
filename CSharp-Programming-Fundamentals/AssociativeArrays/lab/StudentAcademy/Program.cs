using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> gradesByStudent = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradesByStudent.ContainsKey(student))
                {
                    List<double> grades = new List<double>();
                    grades.Add(grade);
                    gradesByStudent.Add(student, grades);
                }
                else
                {
                    gradesByStudent[student].Add(grade);
                }
            }

            foreach (var student in gradesByStudent)
            {
                double averageGrade = student.Value.Average();
                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
            }
        }
    }
}
