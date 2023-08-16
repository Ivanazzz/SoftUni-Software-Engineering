using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            List<int> peopleInEachWagon = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int wagon = 0; wagon < peopleInEachWagon.Count; wagon++)
            {
                for (int people = peopleInEachWagon[wagon]; people < 4; people++)
                {
                    if(waitingPeople > 0)
                    {
                        peopleInEachWagon[wagon]++;
                        waitingPeople--;
                    }
                }
            }

            bool isFull = true;
            foreach (int wagon in peopleInEachWagon)
            {
                if(wagon < 4)
                {
                    isFull = false;
                }
            }

            if(isFull && waitingPeople == 0)
            {
                Console.WriteLine(string.Join(" ", peopleInEachWagon));
            }
            else if (isFull && waitingPeople > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
                Console.WriteLine(string.Join(" ", peopleInEachWagon));
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", peopleInEachWagon));
            }
        }
    }
}
