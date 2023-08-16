namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    public class GymsTests
    {
        [Test]
        public void CreateAthleteShouldSuccess()
        {
            Athlete athlete = new Athlete("Peter");

            Assert.AreEqual("Peter", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void CreateGymShouldSuccess()
        {
            Gym gym = new Gym("Pulse", 15);

            Assert.AreEqual("Pulse", gym.Name);
            Assert.AreEqual(15, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void CreateGymWithNullOrEmptyStringNameShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 15);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(String.Empty, 15);
            });
        }

        [Test]
        public void CreateGymWithNegativeCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -1);
            });
        }

        [Test]
        public void AddAthleteShouldSuccess()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void AddAthleteShouldThrowWithFullCapacity()
        {
            Gym gym = new Gym("Pulse", 1);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
        }

        [Test]
        public void RemoveAthleteShouldSuccess()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrowWithNonExistant()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Non existant");
            });
        }

        [Test]
        public void InjureAthleteShouldSuccess()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Athlete injuredAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreSame(athlete, injuredAthlete);
        }

        [Test]
        public void InjureAthleteShouldThrowWithNonExistant()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Non existant");
            });
        }

        [Test]
        public void ReportShouldSuccessWithNoneInjuredAthletes()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual("Active athletes at Pulse: Peter, Ivan", gym.Report());
        }

        [Test]
        public void ReportShouldSuccessWithOneInjuredAthlete()
        {
            Gym gym = new Gym("Pulse", 3);

            Athlete athlete = new Athlete("Peter");
            Athlete athlete2 = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual("Active athletes at Pulse: Ivan", gym.Report());
        }

        [Test]
        public void ReportShouldSuccessWithEmptyGym()
        {
            Gym gym = new Gym("Pulse", 3);

            Assert.AreEqual("Active athletes at Pulse: ", gym.Report());
        }
    }
}
