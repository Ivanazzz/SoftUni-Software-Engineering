using System;
using System.Collections.Generic;

namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>(); 

            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = new Engine
                { 
                    Model = model,
                    Power = power,
                };


                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (input.Length == 3)
                {
                    bool isDisplacement = int.TryParse(input[2], out int displacement);
                    if (isDisplacement)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = input[2];
                    }
                }

                engines.Add(model, engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines[input[1]];

                Car car = new Car 
                { 
                    Model = model,
                    Engine = engine,
                };

                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];

                    car.Weight = weight;
                    car.Color = color;
                }
                else if (input.Length == 3)
                {
                    bool isWeight = int.TryParse(input[2], out int weight);

                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = input[2];
                    }
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                car.PrintCarInfo(car);
            }
        }
    }
}
