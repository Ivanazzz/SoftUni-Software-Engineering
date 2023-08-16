using System;
using System.Collections.Generic;

namespace NeedforSpeedIII
{
    internal class Program
    {
        public const int TankCapacity = 75;

        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                cars.Add(carInfo[0], new Car(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2])));
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Stop")
                {
                    break;
                }

                string action = tokens[0];
                string car = tokens[1];

                switch (action)
                {
                    case "Drive":
                        Drive(car, int.Parse(tokens[2]), int.Parse(tokens[3]), cars);
                        break;
                    case "Refuel":
                        Refuel(car, int.Parse(tokens[2]), cars);
                        break;
                    case "Revert":
                        Revert(car, int.Parse(tokens[2]), cars);
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        private static void Drive(string car, int distance, int fuel, Dictionary<string, Car> cars)
        {
            if (cars[car].Fuel >= fuel)
            {
                cars[car].Mileage += distance;
                cars[car].Fuel -= fuel;
                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (cars[car].Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {car}!");
                    cars.Remove(car);
                }
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }

        private static void Refuel(string car, int fuel, Dictionary<string, Car> cars)
        {
            int usedFuel = 0;

            if (cars[car].Fuel + fuel > TankCapacity)
            {
                usedFuel = TankCapacity - cars[car].Fuel;
            }
            else
            {
                usedFuel = fuel;
            }

            cars[car].Fuel += usedFuel;
            Console.WriteLine($"{car} refueled with {usedFuel} liters");
        }

        private static void Revert(string car, int kilometers, Dictionary<string, Car> cars)
        {
            cars[car].Mileage -= kilometers;
            if (cars[car].Mileage >= 10000)
            {
                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                cars[car].Mileage = 10000;
            }
        }
    }

    internal class Car
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
}
