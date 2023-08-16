using System;
using System.Collections.Generic;

namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> targetedCities = new Dictionary<string, City>(); 

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("||");
                if (tokens[0] == "Sail")
                {
                    break;
                }
                
                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (!targetedCities.ContainsKey(city))
                {
                    City currentCity = new City(city, population, gold);
                    targetedCities.Add(city, currentCity);
                    continue;
                }

                targetedCities[city].Population += population;
                targetedCities[city].Gold += gold;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("=>");
                if (tokens[0] == "End")
                {
                    break;
                }

                string action = tokens[0];
                string city = tokens[1];

                switch (action)
                {
                    case "Plunder":
                        int people = int.Parse(tokens[2]);
                        int gold = int.Parse(tokens[3]);

                        targetedCities[city].Population -= people;
                        targetedCities[city].Gold -= gold;

                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (targetedCities[city].Population <= 0 || targetedCities[city].Gold <= 0)
                        {
                            targetedCities.Remove(city);
                            Console.WriteLine($"{city} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        int goldToIncrease = int.Parse(tokens[2]);

                        if (goldToIncrease < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }

                        targetedCities[city].Gold += goldToIncrease;
                        Console.WriteLine($"{goldToIncrease} gold added to the city treasury. {city} now has {targetedCities[city].Gold} gold.");
                        break;
                }
            }

            if (targetedCities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targetedCities.Count} wealthy settlements to go to:");
                foreach (var city in targetedCities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    internal class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
    }
}
