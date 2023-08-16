using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    internal class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            this.TravelledDistance = 0;

        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(Car carModel, int amountOfkm)
        {
            if (carModel.FuelAmount >= amountOfkm * carModel.FuelConsumptionPerKilometer)
            {
                carModel.FuelAmount -= amountOfkm * carModel.FuelConsumptionPerKilometer;
                carModel.TravelledDistance += amountOfkm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
