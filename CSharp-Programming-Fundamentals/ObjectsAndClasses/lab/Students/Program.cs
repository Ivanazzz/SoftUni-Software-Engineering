using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInformation = Console.ReadLine().Split();
                Student student = new Student(studentInformation[0], studentInformation[1], float.Parse(studentInformation[2]));
                students.Add(student);
            }

            students = students.OrderByDescending(currStudend => currStudend.Grade).ToList();

            students.ForEach(student => Console.WriteLine(student));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}
