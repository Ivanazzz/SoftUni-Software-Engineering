using System;

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double averageGrade = 0;
            int year = 0;
            int counter = 0;
            bool isValid = true;

            while (year < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    counter++;
                    if (counter > 1)
                    {
                        isValid = false;
                        Console.WriteLine($"{name} has been excluded at {year} grade");
                        break;
                    }
                }
                else
                {
                    averageGrade += grade;
                }
                year++;
            }

            if (isValid)
            {
                Console.WriteLine($"{name} graduated. Average grade: {(averageGrade / year):F2}");
            }
        }
    }
}
