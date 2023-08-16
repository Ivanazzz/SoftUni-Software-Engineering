using System;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByCourses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" : ");
                if (tokens[0] == "end")
                {
                    break;
                }

                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!studentsByCourses.ContainsKey(courseName))
                {
                    List<string> students = new List<string>();
                    students.Add(studentName);
                    studentsByCourses.Add(courseName, students);
                }
                else
                {
                    studentsByCourses[courseName].Add(studentName);
                }
            }

            foreach (var course in studentsByCourses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (string student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
