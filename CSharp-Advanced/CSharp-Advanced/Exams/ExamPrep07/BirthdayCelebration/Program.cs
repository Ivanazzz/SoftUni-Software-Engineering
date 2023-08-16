using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wastedGramsOfFood = 0;

            while (guests.Any() && plates.Any())
            {
                if (plates.Peek() >= guests[0])
                {
                    int foodLeft = plates.Pop() - guests[0];
                    wastedGramsOfFood += foodLeft;
                    guests.RemoveAt(0);
                }
                else
                {
                    guests[0] -= plates.Pop();
                }
            }

            if (plates.Any())
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            else
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");

            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}
