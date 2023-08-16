namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double TUNED_CAR_FUEL_AVAILABLE = 65;
        private const double TUNED_CAR_FUEL_CONSUMPTION_PER_RACE = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, TUNED_CAR_FUEL_AVAILABLE, TUNED_CAR_FUEL_CONSUMPTION_PER_RACE)
        {

        }

        public override void Drive()
        {
            base.Drive();

            double amount = HorsePower - (HorsePower * 0.03);
            HorsePower = (int) Math.Round(amount);
        }
    }
}
