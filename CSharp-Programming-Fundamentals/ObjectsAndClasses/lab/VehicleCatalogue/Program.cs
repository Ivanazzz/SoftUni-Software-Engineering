using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0] == "End")
                {
                    break;
                }

                VehicleType vehicleType;
                bool isVehicleTypeParseSuccessul = Enum.TryParse(tokens[0], true, out vehicleType);
                
                if (isVehicleTypeParseSuccessul)
                {
                    string model = tokens[1];
                    string color = tokens[2];
                    int horsepower = int.Parse(tokens[3]);

                    var currentVehicle = new Vehicle(vehicleType, model, color, horsepower);
                    vehicles.Add(currentVehicle);
                }
            }

            while (true)
            {
                string currentModel = Console.ReadLine();
                if (currentModel == "Close the Catalogue")
                {
                    break;
                }

                var desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == currentModel);
                Console.WriteLine(desiredVehicle);
            }

            var cars = vehicles.Where(vehicle => vehicle.Type == VehicleType.Car).ToList();
            var trucks = vehicles.Where(vehicle => vehicle.Type == VehicleType.Truck).ToList();

            double carsAvrgHorsepower = cars.Count > 0 ? cars.Average(car => car.Horesepower) : 0;
            double trucksAvrgHorsepower = trucks.Count > 0 ? trucks.Average(truck => truck.Horesepower) : 0;

            Console.WriteLine($"Cars have average horsepower of: {carsAvrgHorsepower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvrgHorsepower:f2}.");
        }
    }

    enum VehicleType
    { 
        Car,
        Truck
    }

    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horesepower = horsepower;
        }

        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horesepower { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Type: {Type}");
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Horsepower: {Horesepower}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
