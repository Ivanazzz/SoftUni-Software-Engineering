using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int index = 0;
            Dictionary<int, Tire[]> tiresByIndex = new Dictionary<int, Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires")
                {
                    break;
                }
                string[] inputTires = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire (int.Parse(inputTires[0]), double.Parse(inputTires[1])),
                    new Tire (int.Parse(inputTires[2]), double.Parse(inputTires[3])),
                    new Tire (int.Parse(inputTires[4]), double.Parse(inputTires[5])),
                    new Tire (int.Parse(inputTires[6]), double.Parse(inputTires[7])),
                };

                tiresByIndex.Add(index, tires);
                index++;
            }

            index = 0;
            Dictionary<int, Engine> engineByIndex = new Dictionary<int, Engine>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engines done")
                {
                    break;
                }
                string[] inputEngine = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(inputEngine[0]), double.Parse(inputEngine[1]));

                engineByIndex.Add(index, engine);
                index++;
            }

            index = 0;
            Dictionary<int, Car> carsByIndex = new Dictionary<int, Car>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Show special")
                {
                    break;
                }
                string[] inputCar = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = inputCar[0];
                string model = inputCar[1];
                int year = int.Parse(inputCar[2]);
                double fuelQuantity = double.Parse(inputCar[3]);
                double fuelConsumption = double.Parse(inputCar[4]);
                int indexForEngine = int.Parse(inputCar[5]);
                int indexForTires = int.Parse(inputCar[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineByIndex[indexForEngine], tiresByIndex[indexForTires]);

                carsByIndex.Add(index, car);
                index++;
            }

            foreach (Car car in carsByIndex.Values)
            {
                if (car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    car.Tires.Sum(c => c.Pressure) >= 9 && car.Tires.Sum(c => c.Pressure) <= 10)
                {
                    car.Drive(20);

                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
