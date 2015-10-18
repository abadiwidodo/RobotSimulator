using NUnit.Framework;
using Robot.Models.Command;
using Robot.Utilities.Extensions;

namespace Robot.UnitTest.Command
{
    [TestFixture]
    public class CommandTypeUnitTests
    {
        [TestCase("MOVE", CommandType.Move)]
        [TestCase("PLACE", CommandType.Place)]
        [TestCase("RIGHT", CommandType.Right)]
        [TestCase("LEFT", CommandType.Left)]
        [TestCase("REPORT", CommandType.Report)]
        [TestCase("JUMP", CommandType.Unknown)]
        [TestCase("FLY", CommandType.Unknown)]
        public void Command_Name_String_ToEnum_Should_Return_Correct_Command_Type(string commandInputString, CommandType expectedCommandType  )
        {
            Assert.AreEqual(commandInputString.ToEnum<CommandType>(), expectedCommandType);
        }
    }
}
