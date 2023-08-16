using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleToElevate = int.Parse(Console.ReadLine());
            int capacityOfPeople = int.Parse(Console.ReadLine());

            double coursesWithReminder = (double)peopleToElevate / capacityOfPeople;

            Console.WriteLine(Math.Ceiling(coursesWithReminder));
        }
    }
}
