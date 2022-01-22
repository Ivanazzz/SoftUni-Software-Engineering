using System;

namespace Firm
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int hoursNeeded = int.Parse(Console.ReadLine());
			int daysAvailable = int.Parse(Console.ReadLine());
			int employeesWorkingOvertime = int.Parse(Console.ReadLine());
			double learningHours = daysAvailable - (daysAvailable * 0.1);
			double workingHours = learningHours * 8;
			double overtimeWorkingHours = employeesWorkingOvertime * 2 * daysAvailable;
			double totalWorkingHours = workingHours + overtimeWorkingHours;

			if (totalWorkingHours >= hoursNeeded)
			{
				Console.WriteLine($"Yes!{Math.Floor(totalWorkingHours) - hoursNeeded} hours left.");
			}
			else
			{
				Console.WriteLine($"Not enough time!{Math.Abs(Math.Floor(totalWorkingHours) - hoursNeeded)} hours needed.");
			}
		}
    }
}
