using System.Collections.Generic;
using NUnit.Framework;
using Robot.Models;
using Robot.Models.Command;
using Robot.Models.Extensions;
using Robot.Models.Stage;
using Robot.Utilities.Logs;

namespace Robot.Web.IntegrationTests
{
    [TestFixture]
    public class RobotSimulatorTest
    {
        protected IRobot robot;
        
        [SetUp]
        public void SetUp()
        {
            Table table = new Table(5, 5);
            robot = new NormalRobot(table, new StringBuilderLogger());
        }

        [Test]
        public void Test_Scenario_1()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 0,0,NORTH");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            string test = robot.GetReport();
            Assert.AreEqual("0,2,NORTH\r\n", robot.GetReport());

        }

        [Test]
        public void Test_Scenario_2()        
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 0,0,NORTH");
            stringCommands.Add("LEFT");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("0,0,WEST\r\n", robot.GetReport());
        }

        [Test]
        public void Test_Scenario_3()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 1,2,EAST");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("3,3,NORTH\r\n", robot.GetReport());
        }


        [Test]
        public void Test_Scenario_4()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("RIGHT");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual(string.Empty, robot.GetReport());
        }

        [Test]
        public void Test_Scenario_5()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("PLACE 4,4,NORTH");
            stringCommands.Add("LEFT");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("2,4,SOUTH\r\n", robot.GetReport());
        }

        [Test]
        public void Test_Scenario_6()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("PLACE 4,4,NORTH");
            stringCommands.Add("LEFT");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("REPORT");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("LEFT");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("2,4,SOUTH\r\n2,2,EAST\r\n", robot.GetReport());
        }

        [Test]
        public void Test_Scenario_7()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 1.5,1.5,NORTH");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual(string.Empty, robot.GetReport());
        }

        [Test]
        public void Test_Scenario_8()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE -1,-1,NORTH");
            stringCommands.Add("LEFT");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual(string.Empty, robot.GetReport());
        }

        [Test]
        public void Test_Scenario_9()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 0, 0, SOUTH");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("0,0,SOUTH\r\n", robot.GetReport());
        }

        [Test]
        public void Test_Scenario_10()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 4,4,NORTH");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");
            stringCommands.Add("RIGHT");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("4,4,NORTH\r\n4,4,EAST\r\n", robot.GetReport());
        }

        protected void RunCommands(List<string> stringCommands)
        {
            foreach (string cmd in stringCommands)
            {
                //validate input string first
                if (cmd.IsValidRobotCommand())
                {
                    ICommand command = CommandFactory.Get(cmd, robot);
                    if (command != null) command.Execute();
                }
            }
        }
    }
}
