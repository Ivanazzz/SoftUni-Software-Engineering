using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            Drones = new Dictionary<string, Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Dictionary<string, Drone> Drones;
        public int Count { get => Drones.Count; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }
            else if (!(drone.Range >= 5 && drone.Range <= 15))
            {
                return "Invalid drone.";
            }
            else if (this.Capacity == 0)
            {
                return "Airfield is full.";
            }
            else
            {
                Drones.Add(drone.Name, drone);
                this.Capacity--;

                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.ContainsKey(name))
            {
                Drones.Remove(name);
                this.Capacity++;

                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removedDronesCount = 0;

            foreach (var drone in Drones.Values.Where(x => x.Brand == brand))
            {
                Drones.Remove(drone.Name);
                removedDronesCount++;
                this.Capacity++;
            }

            return removedDronesCount;
        }

        public Drone FlyDrone(string name)
        {
            if (Drones.ContainsKey(name))
            {
                Drones[name].Available = false;

                return Drones[name];
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = new List<Drone>();

            foreach (var drone in Drones.Values.Where(x => x.Range >= range))
            {
                flyDrones.Add(drone);
                drone.Available = false;
            }

            return flyDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in Drones.Values.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
