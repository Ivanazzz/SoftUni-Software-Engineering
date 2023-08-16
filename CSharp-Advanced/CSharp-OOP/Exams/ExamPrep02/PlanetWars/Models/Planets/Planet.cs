using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        private readonly IRepository<IMilitaryUnit> units;
        private readonly IRepository<IWeapon> weapons;

        private Planet()
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public Planet(string name, double budget)
            : this()
        {
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get
            {
                return budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower
            => MilitaryPowerSetter();

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
            => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => weapons.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
            => Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string unitsOutput = units.Models.Any()
                ? String.Join(", ", units.Models.Select(u => u.GetType().Name))
                : "No units";
            string weaponsOutput = weapons.Models.Any()
                ? String.Join(", ", weapons.Models.Select(w => w.GetType().Name))
                : "No weapons";

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {unitsOutput}");
            sb.AppendLine($"--Combat equipment: {weaponsOutput}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            
            return sb.ToString().Trim();
        }

        private double MilitaryPowerSetter()
        {
            double totalAmount = 0;

            totalAmount = units.Models.Sum(u => u.EnduranceLevel)
                + weapons.Models.Sum(w => w.DestructionLevel);

            if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }
            if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
