using System;

namespace VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentBookPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysForReading = int.Parse(Console.ReadLine());
            int totalHours = currentBookPages / pagesPerHour;
            int hoursPerDay = totalHours / daysForReading;
            Console.WriteLine(hoursPerDay);
        }
    }
}
