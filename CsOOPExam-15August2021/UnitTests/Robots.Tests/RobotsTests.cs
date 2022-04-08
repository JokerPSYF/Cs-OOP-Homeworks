using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        [Test]
        public void RobotCtorCheck()
        {
            Robot robot = new Robot("Todor", 100);

            Assert.AreEqual("Todor", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void RobotManagerCtorCheck()
        {
            RobotManager manager = new RobotManager(15);

            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(15, manager.Capacity);
        }

        [Test]
        public void Capacity_ThrowExceprion()
        {
            RobotManager manager;

            Assert.Throws<ArgumentException>
                (() => manager = new RobotManager(-15));
        }

        [Test]
        public void AddThrowWhenAddSameRobot()
        {
            RobotManager manager = new RobotManager(15);

            Robot robot = new Robot("Todor", 100);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>
                (() => manager.Add(robot));
        }

        [Test]
        public void AddThrowWhenCapacitIsFull()
        {
            RobotManager manager = new RobotManager(1);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>
                (() => manager.Add(robot1));
        }

        [Test]
        public void RemoveThrowException()
        {
            RobotManager manager = new RobotManager(1);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>
                (() => manager.Remove("Teo"));
        }

        [Test]
        public void RemoveRobot()
        {
            RobotManager manager = new RobotManager(1);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);
            manager.Remove("Todor");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WorkThrowWhenRobotIsNull()
        {
            RobotManager manager = new RobotManager(2);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);
            manager.Add(robot1);

            Assert.Throws<InvalidOperationException>
                (() => manager.Work("T", "Clean", 15));
        }

        [Test]
        public void WorkThrowWhenDoesntHaveBattery()
        {
            RobotManager manager = new RobotManager(2);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);
            manager.Add(robot1);

            Assert.Throws<InvalidOperationException>
                (() => manager.Work("Teo", "Clean", 100));
        }

        [Test]
        public void WorkMethodWorksFine()
        {
            RobotManager manager = new RobotManager(2);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);
            manager.Add(robot1);
            manager.Work("Todor", "Clean", 75);
            
            Assert.AreEqual(25, robot.Battery);
        }
        
        [Test]
        public void ChargeMethodThrows()
        {
            RobotManager manager = new RobotManager(2);

            Assert.Throws<InvalidOperationException>
                (() => manager.Charge("Nobody"));
        }

        [Test]
        public void ChargeMethodWorksFine()
        {
            RobotManager manager = new RobotManager(2);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);

            manager.Add(robot);
            manager.Add(robot1);
            manager.Work("Todor", "Clean", 75);
            manager.Charge("Todor");

            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void CountCheck()
        {
            RobotManager manager = new RobotManager(10);

            Robot robot = new Robot("Todor", 100);
            Robot robot1 = new Robot("Teo", 99);
            Robot robot2 = new Robot("Todor2", 100);
            Robot robot3 = new Robot("Teo3", 99);
            Robot robot4 = new Robot("Todor4", 100);
            Robot robot5 = new Robot("Teo5", 99);

            manager.Add(robot);
            manager.Add(robot1);
            manager.Add(robot2);
            manager.Add(robot3);
            manager.Add(robot4);
            manager.Add(robot5);

            Assert.AreEqual(6, manager.Count);
        }
    }
}
