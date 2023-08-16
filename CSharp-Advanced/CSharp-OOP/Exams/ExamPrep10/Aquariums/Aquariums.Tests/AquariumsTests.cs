namespace Aquariums.Tests
{
    using System;

    using NUnit.Framework;

    public class AquariumsTests
    {
        private string fishName = "Nemo";
        private string aquariumName = "SeaLife";
        private int aquariumCapacity = 2;

        [Test]
        public void AquariumConstructorShouldInitializeCorrectly()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);

            Assert.AreEqual(aquariumName, aquarium.Name);
            Assert.AreEqual(aquariumCapacity, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AquariumNameSetterShouldThrowWithNullOrEmptyName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, aquariumCapacity);
            });
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void AquariumCapacitySetterShouldThrowWithNegativeCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium(aquariumName, capacity);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCountShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AquariumAddShouldWorkWithFishesCountBelowCapacity()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AquariumAddShouldThrowWithFullCapacity()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish1 = new Fish(fishName);
            Fish fish2 = new Fish("Peter");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Ivan"));
            });
        }

        [Test]
        public void AquariumRemoveFishShouldWorkWithExistingFish()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);
            aquarium.RemoveFish(fishName);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void AquariumRemoveFishThrowWorkWithNonExistantFish()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Peter");
            });
        }

        [Test]
        public void AquariumSellFishShouldWorkWithExistingFish()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);
            Fish soldFish = aquarium.SellFish(fishName);

            Assert.IsFalse(soldFish.Available);
        }

        [Test]
        public void AquariumSellFishThrowWorkWithNonExistantFish()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish soldFish = aquarium.SellFish("Peter");
            });
        }

        [Test]
        public void AquariumReportShouldWorkWithMultipleFishes()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Fish fish1 = new Fish(fishName);
            Fish fish2 = new Fish("Peter");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            string expectedOutput = "Fish available at SeaLife: Nemo, Peter";
            string actualOutput = aquarium.Report();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void AquariumReportShouldWorkWithEmptyAquarium()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);

            string expectedOutput = "Fish available at SeaLife: ";
            string actualOutput = aquarium.Report();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
