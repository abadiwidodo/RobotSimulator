using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Robot.Models.Extensions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Robot.UnitTest
{
    [TestClass]
    public class RobotCommandUnitTests
    {
        [TestCase("PLACE 1,1,NORTH", true)]
        [TestCase("PLACE 1,1", false)]
        [TestCase("PLACE -1,-1,SOUTH", true)]
        [TestCase("PLACE 1,1, SOUTH", true)]
        [TestCase("PLACE 1, 1,SOUTH", true)]
        [TestCase("PLACE 1, 1, SOUTH", true)]
        [TestCase("PLACE 1.5,1.5", false)]
        [TestCase("RIGHT", true)]
        [TestCase("LEFT", true)]
        [TestCase("MOVE", true)]
        [TestCase("REPORT", true)]
        public void Is_Robot_Command_Input_Strings_Valid(string commandStringInput, Boolean isCorrectCommandString)
        {
            // Act
            Assert.AreEqual(isCorrectCommandString, commandStringInput.IsValidRobotCommand());
        }
    }
}
