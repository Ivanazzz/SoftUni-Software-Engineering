using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> usernameByLicensePlateNumber = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string username = tokens[1];

                switch (command)
                {
                    case "register":
                        string licensePlateNumber = tokens[2];
                        Register(usernameByLicensePlateNumber, username, licensePlateNumber);
                        break;
                    case "unregister":
                        Unregister(usernameByLicensePlateNumber, username);
                        break;
                }
            }

            foreach (var place in usernameByLicensePlateNumber)
            {
                Console.WriteLine($"{place.Key} => {place.Value}");
            }
        }

        private static void Register(Dictionary<string, string> usernameByLicensePlateNumber, string username, string licensePlateNumber)
        {
            if (usernameByLicensePlateNumber.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {usernameByLicensePlateNumber[username]}");
            }
            else
            {
                usernameByLicensePlateNumber.Add(username, licensePlateNumber);
                Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
            }
        }

        private static void Unregister(Dictionary<string, string> usernameByLicensePlateNumber, string username)
        {
            if (!usernameByLicensePlateNumber.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                usernameByLicensePlateNumber.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
        }
    }
}
