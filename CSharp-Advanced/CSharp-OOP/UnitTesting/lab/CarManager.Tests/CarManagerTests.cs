namespace CarManager.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorShouldInitializeCar()
        {
            string expectedMake = "Audi";
            string expectedModel = "Q7";
            double expectedFuelConsumption = 1.5;
            double expectedFuelAmount = 0;
            double expectedFuelCapacity = 100;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelAmount = car.FuelAmount;
            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase("BMW")]
        [TestCase("S")]
        [TestCase("very very very very very very very very very very very very long make name")]
        public void MakeSetterShouldSetValueWithValidData(string make)
        {
            Car car = new Car(make, "A5", 1.2, 100);

            string expectedMake = make;
            string actualMake = car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowExceptionWithNullOrEmptyData(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "A5", 1.2, 100);
            }, "Make cannot be null or empty!");
        }

        [TestCase("Q7")]
        [TestCase("a")]
        [TestCase("very very very very very very very very very very very very long mODEL name")]
        public void ModelSetterShouldSetValueWithValidData(string model)
        {
            Car car = new Car("Audi", model, 1.2, 100);

            string expectedModel = model;
            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowExceptionWithNullOrEmptyData(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", model, 1.2, 100);
            }, "Model cannot be null or empty!");
        }

        [TestCase(1)]
        [TestCase(50.8)]
        [TestCase(double.MaxValue)]
        public void FuelConsumptionSetterShouldSetValueWithValidData(double fuelConsumption)
        {
            Car car = new Car("Audi", "A5", fuelConsumption, 100);

            double expectedFuelConsumption = fuelConsumption;
            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-200)]
        [TestCase(double.MinValue)]
        public void FuelConsumptionSetterShouldThrowExceptionWithZeroOrNegataiveData(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A5", fuelConsumption, 100);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(1)]
        [TestCase(50.8)]
        [TestCase(double.MaxValue)]
        public void FuelCapacitySetterShouldSetValueWithValidData(double fuelCapacity)
        {
            Car car = new Car("Audi", "A5", 1.2, fuelCapacity);

            double expectedFuelCapacity = fuelCapacity;
            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-200)]
        [TestCase(double.MinValue)]
        public void FuelCapacitySetterShouldThrowExceptionWithZeroOrNegataiveData(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A5", 1.2, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(1)]
        [TestCase(80)]
        [TestCase(40)]
        public void RefuelShouldSuccessWithValidData_FuelAmountEqualOrBelowFuelCapacity(double fuelForRefuel)
        {
            Car car = new Car("Audi", "A5", 1.2, 80);
            car.Refuel(fuelForRefuel);

            double expectedFuelAmount = fuelForRefuel;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(81)]
        [TestCase(180)]
        [TestCase(double.MaxValue)]
        public void RefuelShouldSuccessWithValidData_FuelAmountAboveFuelCapacity(double fuelForRefuel)
        {
            Car car = new Car("Audi", "A5", 1.2, 80);
            car.Refuel(fuelForRefuel);

            double expectedFuelAmount = 80;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(double.MinValue)]
        public void RefuelShouldThrowExceptionWithZeroOrNegativeData(double fuelForRefuel)
        {
            Car car = new Car("Audi", "A5", 1.2, 80);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelForRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(400)]
        [TestCase(4800)]
        public void DriveShouldSuccessWithValidData(double distance)
        {
            Car car = new Car("Audi", "A5", 1.5, 80);
            car.Refuel(72);

            double neededFuel = (distance / 100) * 1.5;
            double expectedFuelAmount = 72 - neededFuel;

            car.Drive(distance);
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(600)]
        [TestCase(9000)]
        [TestCase(double.MaxValue)]
        public void DriveShouldThrowExceptionWithDataBiggerThanFuelAmount(double distance)
        {
            Car car = new Car("Audi", "A5", 2, 20);
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }
    }
}