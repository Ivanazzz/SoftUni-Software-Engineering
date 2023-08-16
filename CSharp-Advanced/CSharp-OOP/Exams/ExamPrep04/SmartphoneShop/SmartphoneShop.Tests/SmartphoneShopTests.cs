using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        private string modelName = "IPhone 13 Pro Max";
        private int maxCharge = 100;
        private int capacity = 3;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(modelName, maxCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void NegativeCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-8);
            });
        }

        [Test]
        public void AddSmartphoneShouldWork()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void DublicateSmartphonesShouldThrow()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("IPhone 13 Pro Max", 50));
            });
        }

        [Test]
        public void PhoneCannotBeAddedWhenCapacityIsFull()
        {
            shop.Add(new Smartphone("1", 1));
            shop.Add(new Smartphone("2", 2));
            shop.Add(new Smartphone("3", 3));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("4", 4));
            });
        }

        [Test]
        public void RemoveSmartphoneShouldWork()
        {
            shop.Add(smartphone);
            shop.Remove(modelName);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void RemoveShouldThrowWhenPhoneIsNotFound()
        {   
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Non existant");
            });
        }

        [Test]
        public void PhoneShouldReduceBatteryCharge()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 50);

            Assert.AreEqual(maxCharge - 50, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Non existant", 10);
            });
        }

        [Test]
        public void TestPhoneShouldNotWorkOnUnchargedPhones()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, maxCharge + 1);
            });
        }

        [Test]
        public void ChargePhoneShouldSetBatteryToMax()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 50);
            shop.ChargePhone(modelName);

            Assert.AreEqual(maxCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Non existant");
            });
        }
    }
}