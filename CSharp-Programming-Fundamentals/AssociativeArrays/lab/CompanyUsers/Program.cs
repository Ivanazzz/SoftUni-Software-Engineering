using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employeeByCompany = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");
                if (tokens[0] == "End")
                {
                    break;
                }

                string company = tokens[0];
                string employeeID = tokens[1];

                if (!employeeByCompany.ContainsKey(company))
                {
                    employeeByCompany.Add(company, new List<string>());
                }
                
                if (employeeByCompany[company].Contains(employeeID))
                {
                    continue;
                }

                employeeByCompany[company].Add(employeeID);
            }

            foreach (var company in employeeByCompany)
            {
                Console.WriteLine(company.Key);

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
