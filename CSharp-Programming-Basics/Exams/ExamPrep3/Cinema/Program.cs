using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            int totalTicketsPrice = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Movie time!")
                {
                    Console.WriteLine($"There are {capacity} seats left in the cinema.");
                    break;
                }
                int people = int.Parse(command);

                if (people > capacity)
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                else
                {
                    capacity -= people;
                    if (people % 3 == 0)
                    {
                        totalTicketsPrice += people * 5 - 5;
                    }
                    else
                    {
                        totalTicketsPrice += people * 5;
                    }
                }
            }

            Console.WriteLine($"Cinema income - {totalTicketsPrice} lv.");
        }
    }
}
