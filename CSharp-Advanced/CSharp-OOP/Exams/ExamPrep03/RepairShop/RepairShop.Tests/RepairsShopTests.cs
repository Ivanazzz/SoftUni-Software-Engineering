using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private const string carModel = "Audi A6";
            private const int numberOfIssues = 1;

            private const string garageName = "Service";
            private const int mechanicsAvailable = 2;

            [Test]
            public void GarageConstructorShouldWork()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);

                Assert.AreEqual(garageName, garage.Name);
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase(null)]
            [TestCase("")]
            public void GarageNameSetterShouldThrowWhenDataIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, mechanicsAvailable);
                }, "Invalid garage name.");
            }

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(int.MinValue)]
            public void GarageMechanicsAvailableSetterShouldThrowWhenDataNegative(int count)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage(garageName, count);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void GarageAddCarShouldWorkWhenMechanicsAvailable()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void GarageAddCarShouldThrowWhenNoMechanicsAvailable()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car1 = new Car(carModel, numberOfIssues);
                Car car2 = new Car("BMW X5", 5);
                Car car3 = new Car("VW Passat", 0);

                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car3);
                }, "No mechanic available.");
            }

            [Test]
            public void GarageFixCarShouldWorkWithExistingCar()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                Car fixedCar = garage.FixCar(carModel);

                Assert.AreEqual(0, fixedCar.NumberOfIssues);
            }

            [Test]
            public void GarageFixCarShouldThrowWithNonExistentCar()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("BMW X5");
                }, $"The car BMW X5 doesn't exist.");
            }

            [Test]
            public void GarageRemoveFixedCarShouldWorkWithFixedCars()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);
                Car fixedCar = garage.FixCar(carModel);

                garage.RemoveFixedCar();

                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void GarageRemoveFixedCarShouldThrowWhenNoCarsFixed()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }

            [Test]
            public void GarageReportShouldWorkWithCarsToBeFixed()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car1 = new Car(carModel, numberOfIssues);
                Car car2 = new Car("BMW X5", 5);

                garage.AddCar(car1);
                garage.AddCar(car2);

                string expectedOutput = "There are 2 which are not fixed: Audi A6, BMW X5.";

                Assert.AreEqual(expectedOutput, garage.Report());
            }

            [Test]
            public void GarageReportShouldWorkWithNoCarsToBeFixed()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Car car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);
                garage.FixCar(carModel);

                string expectedOutput = "There are 0 which are not fixed: .";

                Assert.AreEqual(expectedOutput, garage.Report());
            }
        }
    }
}