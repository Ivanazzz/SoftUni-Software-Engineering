using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }
            else if (string.IsNullOrWhiteSpace(fish.FishType)
                || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fishToRelease = Fish.FirstOrDefault(f => f.Weight == weight);

            if (fishToRelease != null)
            {
                Fish.Remove(fishToRelease);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.FirstOrDefault(f => f.FishType == fishType);

            return fish;
        }

        public Fish GetBiggestFish()
        {
            Fish biggestFish = Fish.OrderByDescending(f => f.Length).FirstOrDefault();

            return biggestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            Fish = Fish.OrderByDescending(f => f.Length).ToList();

            sb.AppendLine($"Into the {Material}:");
            foreach (Fish fish in Fish)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
