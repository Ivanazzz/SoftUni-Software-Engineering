using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            else if (planet.Army.Any(w => w.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unitToBeAdded = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unitToBeAdded = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unitToBeAdded = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unitToBeAdded = new StormTroopers();
            }

            planet.Spend(unitToBeAdded.Cost);
            planet.AddUnit(unitToBeAdded);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            else if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weaponToBeAdded = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weaponToBeAdded = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weaponToBeAdded = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weaponToBeAdded = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weaponToBeAdded.Price);
            planet.AddWeapon(weaponToBeAdded);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            IPlanet winner = firstPlanet;
            IPlanet loser = secondPlanet;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")
                    && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")
                    || !firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")
                    && !secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    firstPlanet.Spend(firstPlanet.Budget * 0.5);
                    secondPlanet.Spend(secondPlanet.Budget * 0.5);

                    return OutputMessages.NoWinner;
                }
                else if (secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                winner = secondPlanet;
                loser = firstPlanet;
            }

            double loserPossesedWeaponsAndForcesCost = loser.Army.Sum(u => u.Cost)
                + loser.Weapons.Sum(w => w.Price);

            winner.Spend(winner.Budget * 0.5);
            winner.Profit(loser.Budget * 0.5);
            winner.Profit(loserPossesedWeaponsAndForcesCost);
            planets.RemoveItem(loser.Name);

            return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string ForcesReport()
        {
            List<IPlanet> orderedPlanets = planets
                .Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
