using System;

namespace SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            CalculateTime(firstEmployeeEfficiency, secondEmployeeEfficiency, thirdEmployeeEfficiency, students);
        }

        private static void CalculateTime(int firstEmployeeEfficiency, int secondEmployeeEfficiency, int thirdEmployeeEfficiency, int students)
        {
            int hours = 1;
            int totalEmployeesEfficiency = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            while(students > 0)
            {
                if(hours % 4 != 0)
                {
                    students -= totalEmployeesEfficiency;
                }
                hours++;
            }
            hours--;

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
