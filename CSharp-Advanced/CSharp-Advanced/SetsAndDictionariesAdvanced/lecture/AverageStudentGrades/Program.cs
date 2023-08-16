using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!studentGrades.ContainsKey(name))
                { 
                    studentGrades[name] = new List<decimal>();
                }

                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(grade => grade.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
