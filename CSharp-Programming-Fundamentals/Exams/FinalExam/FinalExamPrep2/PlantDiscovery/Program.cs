using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("<->");
                string name = tokens[0];
                int rarity = int.Parse(tokens[1]);

                if (plants.ContainsKey(name))
                {
                    plants[name].Rarity = rarity;
                    continue;
                }

                Plant currentPlant = new Plant(name, rarity);
                plants.Add(name, currentPlant);
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                if (tokens[0] == "Exhibition")
                {
                    break;
                }

                string[] plantInfo = tokens[1].Split(" - ");
                string plantName = plantInfo[0];
                string action = tokens[0];

                if (!plants.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (action)
                {
                    case "Rate":
                        int rating = int.Parse(plantInfo[1]);
                        plants[plantName].Rating.Add(rating);
                        break;
                    case "Update":
                        int rarity = int.Parse(plantInfo[1]);
                        plants[plantName].Rarity = rarity;
                        break;
                    case "Reset":
                        plants[plantName].Rating.Clear();
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants)
            {
                double averageRating = plant.Value.Rating.Count > 0 ? plant.Value.Rating.Average() : 0.00;
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:f2}");
            }
        }
    }

    public class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }

        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = new List<int>();
        }
    }
}
