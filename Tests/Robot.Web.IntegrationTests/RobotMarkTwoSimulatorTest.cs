using System.Collections.Generic;
using NUnit.Framework;
using Robot.Models;
using Robot.Models.Command;
using Robot.Models.Extensions;
using Robot.Models.PlaceableObject;
using Robot.Models.Stage;
using Robot.Utilities;
using Robot.Utilities.Logs;

namespace Robot.Web.IntegrationTests
{
    [TestFixture]
    public class RobotMarkTwoSimulatorTest
    {
        protected IRobot robot;
        
        [SetUp]
        public void SetUp()
        {
            Table table = new Table(5, 5);

            robot = new ToyRobotMarkTwo(table, new StringBuilderLogger());
        }

        [Test]
        public void Robot_Mark2_Test_Scenario_1_Add_Rock_To_Table_Should_Stop_Robot_To_Move_Forward()
        {
            //add rock to spot 2,2
            robot.Table.AddToSpot(new Rock(new Position(new Coordinate(2, 2), Direction.North)));

            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 2,0,NORTH");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("MOVE");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("2,1,NORTH\r\n", robot.GetReport());
        }

        [Test]
        public void Robot_Mark2_Test_Scenario_2_Give_MOVEBACKWARD_Command_Should_Move_Forward()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 2,2,NORTH");
            stringCommands.Add("MOVEBACKWARD");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            Assert.AreEqual("2,1,NORTH\r\n", robot.GetReport());
        }

        [Test]
        public void Robot_Mark2_Test_Scenario_3_Give_TURNAROUND_Command_Should_Turn_Opposite_Direction()
        {
            List<string> stringCommands = new List<string>();

            stringCommands.Add("PLACE 2,2,NORTH");
            stringCommands.Add("TURNAROUND");
            stringCommands.Add("REPORT");

            RunCommands(stringCommands);

            string test = robot.GetReport();
            Assert.AreEqual("2,2,SOUTH\r\n", robot.GetReport());
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
