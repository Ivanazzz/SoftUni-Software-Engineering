using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] studentProperties = Console.ReadLine().Split();
                
                if (studentProperties[0] == "end")
                {
                    break;
                }

                Student student = new Student(studentProperties[0], studentProperties[1], studentProperties[2], studentProperties[3]);

                students.Add(student);
            }

            string cityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (cityName == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, string Age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = Age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
