using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string invitedGuest = Console.ReadLine();
            while (invitedGuest != "PARTY")
            {
                guests.Add(invitedGuest);
                invitedGuest = Console.ReadLine();
            }

            string arrivedGuest = Console.ReadLine();
            while (arrivedGuest != "END")
            {
                guests.Remove(arrivedGuest);
                arrivedGuest = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (string guest in guests)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

            foreach (string guest in guests)
            {
                if (!char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
