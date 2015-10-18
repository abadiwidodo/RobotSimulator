using System;
using Moq;
using NUnit.Framework;
using Robot.Utilities.Logs;

namespace Robot.Utilities.UnitTests.Logs
{
    [TestFixture]
    public class LoggerUnitTests
    {
        //public void Command_Factory_Get_Command_Input_String_Should_Return_Correct_Command_Type(string commandInputString, Type expectedType  )
        //{
        //    // Arrange/Act
        //    ILogger logger = GetLoggerMock().Object;

        //    logger.Log("this is log message");

        //    // Assert
        //    Assert.IsInstanceOf(expectedType, command);
        //}

        private static Mock<ILogger> GetLoggerMock()
        {
            var loggerMock = new Mock<ILogger>();
            //loggerMock.Setup(x=>x.Log(It.IsAny<String>()))
            return loggerMock;
        }
    }
}
