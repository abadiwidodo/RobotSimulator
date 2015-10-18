using System;
using Moq;
using NUnit.Framework;
using Robot.Models;
using Robot.Models.Command;

namespace Robot.UnitTest.Command
{
    [TestFixture]
    public class CommandFactoryUnitTests
    {
        [TestCase("MOVE", typeof(MoveCommand))]
        [TestCase("move", typeof(MoveCommand))]
        [TestCase("RIGHT", typeof(RightCommand))]
        [TestCase("right", typeof(RightCommand))]
        [TestCase("LEFT", typeof(LeftCommand))]
        [TestCase("left", typeof(LeftCommand))]
        [TestCase("REPORT", typeof(ReportCommand))]
        [TestCase("report", typeof(ReportCommand))]
        public void Command_Factory_Get_Command_Input_String_Should_Return_Correct_Command(string commandInputString, Type expectedType  )
        {
            ICommand command = CommandFactory.Get(commandInputString, GetRobotMock().Object);

            Assert.IsInstanceOf(expectedType, command);
        }

        private static Mock<IRobot> GetRobotMock()
        {
            var factoryMock = new Mock<IRobot>();
            return factoryMock;
        }
    }
}
