namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private string presentName = "Surprise";
        private double presentMagic = 2.5;

        [Test]
        public void BagConstructorShouldWork()
        {
            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void BagCreateShouldSuccessWithNonExistantPresent()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);

            string actualOutput = bag.Create(present);

            Assert.AreEqual($"Successfully added present {presentName}.", actualOutput);
        }

        [Test]
        public void BagCreateShouldThrowWithNullPresent()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            }, "Present is null");
        }

        [Test]
        public void BagCreateShouldThrowWithAlreadyExistingPresent()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }

        [Test]
        public void BagRemoveShouldSuccessWithExistingPresent()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);

            string actualOutput = bag.Create(present);
            bool isRemoved = bag.Remove(present);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public void BagRemoveShouldSuccessWithNonExistantPresent()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);
            Present presentToRemove = new Present("Test", presentMagic);

            string actualOutput = bag.Create(present);

            bool isRemoved = bag.Remove(presentToRemove);

            Assert.IsFalse(isRemoved);
        }

        [Test]
        public void BagGetPresentWithLeastMagicShouldSuccess()
        {
            Bag bag = new Bag();
            Present present1 = new Present(presentName, presentMagic);
            Present present2 = new Present("Test", 1.2);

            string actualOutput1 = bag.Create(present1);
            string actualOutput2 = bag.Create(present2);

            Present presentWithLeastMagic = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present2.Name, presentWithLeastMagic.Name);
            Assert.AreEqual(present2.Magic, presentWithLeastMagic.Magic);
        }

        [Test]
        public void BagGetPresentShouldSuccessWithExistingPresent()
        {
            Bag bag = new Bag();
            Present present1 = new Present(presentName, presentMagic);
            Present present2 = new Present("Test", 1.2);

            string actualOutput1 = bag.Create(present1);
            string actualOutput2 = bag.Create(present2);

            Present presentReceived = bag.GetPresent(presentName);

            Assert.AreEqual(presentName, presentReceived.Name);
            Assert.AreEqual(present1.Magic, presentReceived.Magic);
        }

        [Test]
        public void BagGetPresentShouldSuccessWithNonExistantPresent()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);

            string actualOutput = bag.Create(present);

            Present presentReceived = bag.GetPresent("Test");

            Assert.IsNull(presentReceived);
        }

        [Test]
        public void BagGetPresentsShouldSuccess()
        {
            Bag bag = new Bag();
            Present present = new Present(presentName, presentMagic);

            string actualOutput = bag.Create(present);

            int presentsCount = bag.GetPresents().Count;

            Assert.AreEqual(1, presentsCount);
        }
    }
}
