namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        private string robotName = "Alexa";
        private int robotMaximumBattery = 100;
        private int robotManagerCapacity = 2;

        [Test]
        public void RobotManagerConstructorShouldWork()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);

            Assert.AreEqual(0, robotManager.Count);
            Assert.AreEqual(robotManagerCapacity, robotManager.Capacity);
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void RobotManagerCapacityShouldThrowWithNegativeValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void RobotManagerAddShouldWorkNonExistantRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManagerAddShouldThrowWithSameNameRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);
            Robot robotToBeAdded = new Robot(robotName, 50);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robotToBeAdded);
            }, $"There is already a robot with name {robotName}!");
        }

        [Test]
        public void RobotManagerAddShouldThrowWithExistingRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            }, $"There is already a robot with name {robotName}!");
        }

        [Test]
        public void RobotManagerAddShouldThrowWithNoCapacity()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot1 = new Robot(robotName, robotMaximumBattery);
            Robot robot2 = new Robot("Peter", 80);
            Robot robot3 = new Robot("Ivan", 50);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            }, "Not enough capacity!");
        }

        [Test]
        public void RobotManagerRemoveShouldWorkExistingRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);
            robotManager.Remove(robotName);

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveShouldThrowWithNonExistantRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Peter");
            }, $"Robot with the name Peter doesn't exist!");
        }

        [Test]
        public void RobotManagerWorkShouldWorkExistingRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);
            robotManager.Work(robotName, "sing", 40);

            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void RobotManagerWorkShouldThrowWithNonExistantRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Peter", "sing", 40);
            }, $"Robot with the name Peter doesn't exist!");
        }

        [TestCase(101)]
        [TestCase(int.MaxValue)]
        public void RobotManagerWorkShouldThrowWithExistingRobotButNotEnoughBattery(int batteryUsage)
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robotName, "sing", batteryUsage);
            }, $"{robotName} doesn't have enough battery!");
        }

        [Test]
        public void RobotManagerChargeShouldWorkExistingRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);
            robotManager.Work(robotName, "sing", 40);

            robotManager.Charge(robotName);

            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void RobotManagerChargeShouldThrowWithNonExistantRobot()
        {
            RobotManager robotManager = new RobotManager(robotManagerCapacity);
            Robot robot = new Robot(robotName, robotMaximumBattery);

            robotManager.Add(robot);
            robotManager.Work(robotName, "sing", 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Peter");
            }, $"Robot with the name {robotName} doesn't exist!");
        }
    }
}
