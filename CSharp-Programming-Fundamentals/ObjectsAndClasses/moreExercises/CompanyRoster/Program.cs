using System;
using System.Collections.Generic;

namespace CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Department> department = new List<Department>();
            List<Departments> departments = new List<Departments>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split();

                Employee currentEmployee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2]);

            }
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Depratment = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Depratment { get; set; }
    }

    class Department : List<Employee> { }

    class Departments : List<Department> { }
}
