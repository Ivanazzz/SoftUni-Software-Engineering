using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private const string weaponName1 = "Pistol";
            private const double weaponPrice1 = 233.50;
            private const int weaponDestructionLevel1 = 4;

            private const string weaponName2 = "Knife";
            private const double weaponPrice2 = 20;
            private const int weaponDestructionLevel2 = 1;

            private const string planetName = "Mars";
            private const double planetBudget = 1800;
            private List<Weapon> weapons = new List<Weapon>();

            [SetUp]
            public void SetUp()
            {
                weapons.Add(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                weapons.Add(new Weapon(weaponName2, weaponPrice2, weaponDestructionLevel2));
            }

            [TearDown]
            public void TearDown()
            {
                weapons = new List<Weapon>();
            }

            [Test]
            public void WeaponConstructorShouldWork()
            {
                Weapon weapon = new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1);

                Assert.AreEqual(weaponName1, weapon.Name);
                Assert.AreEqual(weaponPrice1, weapon.Price);
                Assert.AreEqual(weaponDestructionLevel1, weapon.DestructionLevel);
            }

            [TestCase(14.90)]
            [TestCase(double.MaxValue)]
            [TestCase(0)]
            public void WeaponPriceSetterShouldSetWithValidData(double price)
            {
                Weapon weapon = new Weapon(weaponName1, price, weaponDestructionLevel1);

                Assert.AreEqual(price, weapon.Price);
            }

            [TestCase(-1)]
            [TestCase(double.MinValue)]
            public void WeaponPriceSetterShouldThrowWithNegativeData(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon(weaponName1, price, weaponDestructionLevel1);
                }, "Price cannot be negative.");
            }

            [TestCase(0)]
            [TestCase(2)]
            public void WeaponIncreaseDestructionLevelShouldWork(int count)
            {
                int destructionLevel = 3;
                Weapon weapon = new Weapon(weaponName1, weaponPrice1, destructionLevel);

                for (int i = 0; i < count; i++)
                {
                    weapon.IncreaseDestructionLevel();
                    destructionLevel++;
                }

                Assert.AreEqual(destructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponIsNuclearShouldReturnFalseWhenBelowTen()
            {
                int destructionLevel = 4;
                Weapon weapon = new Weapon(weaponName1, weaponPrice1, destructionLevel);

                Assert.AreEqual(false, weapon.IsNuclear); ;
            }

            [TestCase(10)]
            [TestCase(15)]
            [TestCase(int.MaxValue)]
            public void WeaponIsNuclearShouldReturnTrueWhenEqualOrGreaterTen(int level)
            {
                Weapon weapon = new Weapon(weaponName1, weaponPrice1, level);

                Assert.AreEqual(true, weapon.IsNuclear); ;
            }

            [Test]
            public void PlanetConstructorShouldWork()
            {
                Planet planet = new Planet(planetName, planetBudget);

                Assert.AreEqual(planetName, planet.Name);
                Assert.AreEqual(planetBudget, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNameShouldThrowWithNullOrEmptyData(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, planetBudget);
                }, "Invalid planet Name");
            }

            [TestCase(-1)]
            [TestCase(double.MinValue)]
            public void PlanetBudgetShouldThrowWithNegativeData(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(planetName, budget);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void PlanetMilitaryPowerRatioShouldWork()
            {
                int expectedRatio = weaponDestructionLevel1 + weaponDestructionLevel2;

                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                planet.AddWeapon(new Weapon(weaponName2, weaponPrice2, weaponDestructionLevel2));

                Assert.AreEqual(expectedRatio, planet.MilitaryPowerRatio);
            }

            [TestCase(0)]
            [TestCase(12.50)]
            public void PlanetProfitShouldWork(double amount)
            {
                double expectedBudget = planetBudget + amount;

                Planet planet = new Planet(planetName, planetBudget);
                planet.Profit(amount);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [TestCase(0)]
            [TestCase(700)]
            public void PlanetSpendFundsShouldWorkWithAmountEqualOrLessThanBudget(double amount)
            {
                double expectedBudget = planetBudget - amount;

                Planet planet = new Planet(planetName, planetBudget);
                planet.SpendFunds(amount);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [TestCase(2000)]
            [TestCase(double.MaxValue)]
            [TestCase(1801)]
            public void PlanetSpendFundsShouldThrowWithAmountGreaterThanBudget(double amount)
            {
                Planet planet = new Planet(planetName, planetBudget);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void PlanetAddWeaponShouldWorkWithUnexistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void PlanetAddWeaponShouldThrowWithExistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                }, $"There is already a {weaponName1} weapon.");
            }

            [Test]
            public void PlanetRemoveWeaponShouldWorkWithExistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                planet.RemoveWeapon(weaponName1);

                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void PlanetRemoveWeaponShouldWorkWithUnexistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                planet.RemoveWeapon(weaponName2);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void PlanetUpgradeWeaponShouldWorkWithExistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));

                int expectedWeaponDestructionLevel = weaponDestructionLevel1 + 2;

                planet.UpgradeWeapon(weaponName1);
                planet.UpgradeWeapon(weaponName1);

                int actualWeaponDestructionLevel = planet.Weapons.FirstOrDefault(w => w.Name == weaponName1).DestructionLevel;

                Assert.AreEqual(expectedWeaponDestructionLevel, actualWeaponDestructionLevel);
            }

            [Test]
            public void PlanetUpgradeWeaponShouldThrowWithUnexistingWeapon()
            {
                Planet planet = new Planet(planetName, planetBudget);
                planet.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weaponName2);
                }, $"{weaponName2} does not exist in the weapon repository of {planetName}");
            }

            [Test]
            public void PlanetDestructOpponentShouldWorkWithWeakerOpponent()
            {
                Planet planet1 = new Planet(planetName, planetBudget);
                Planet planet2 = new Planet("Jupiter", 500);

                planet1.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                planet2.AddWeapon(new Weapon(weaponName2, weaponPrice2, weaponDestructionLevel2));

                string expectedOutput = $"Jupiter is destructed!";

                Assert.AreEqual(expectedOutput, planet1.DestructOpponent(planet2));
            }

            [Test]
            public void PlanetDestructOpponentShouldThrowWithStongerOpponent()
            {
                Planet planet1 = new Planet(planetName, planetBudget);
                Planet planet2 = new Planet("Jupiter", 500);

                planet1.AddWeapon(new Weapon(weaponName1, weaponPrice1, weaponDestructionLevel1));
                planet2.AddWeapon(new Weapon(weaponName2, weaponPrice2, weaponDestructionLevel2));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet2.DestructOpponent(planet1);
                }, $"{planetName} is too strong to declare war to!");
            }
        }
    }
}
