using System;
using Moq;
using NUnit.Framework;
using Robot.Models;
using Robot.Models.Stage;
using Robot.Utilities;
using Robot.Utilities.Logs;

namespace Robot.UnitTest.Stage
{
    /// <summary>
    /// This tests to determine if robot can move forward & if robot can be placed to new position
    /// </summary>
    [TestFixture]
    public class RobotPositionCanMoveUnitTests
    {
        private readonly NormalRobot _robot;

        public RobotPositionCanMoveUnitTests()
        {
            //Set robot with table stage 5x5
            _robot = new NormalRobot(new Table(5, 5), new Mock<ILogger>().Object);
        }

        [TestCase(0, 0, Direction.North, true)]
        [TestCase(1, 1, Direction.North, true)]
        [TestCase(2, 2, Direction.North, true)]
        [TestCase(3, 3, Direction.North, true)]
        [TestCase(4, 4, Direction.North, false)]
        [TestCase(4, 4, Direction.East, false)]
        [TestCase(3, 4, Direction.East, true)]
        [TestCase(2, 4, Direction.East, true)]
        [TestCase(1, 4, Direction.East, true)]
        [TestCase(0, 4, Direction.West, false)]
        [TestCase(0, 4, Direction.North, false)]
        [TestCase(4, 0, Direction.East, false)]
        [TestCase(4, 0, Direction.South, false)]
        public void Can_Robot_In_Given_Coordinate_Facing_Direction_Move_Forward(int x, int y, Direction direction, Boolean isRobotCanMove)
        {
            _robot.Place(x, y, direction);
            Assert.IsTrue(_robot.Table.CanMoveForward(_robot) == isRobotCanMove);
        }

        [TestCase(-1, -1, Direction.North, false)]
        [TestCase(0, 0, Direction.North, true)]
        [TestCase(4, 4, Direction.North, true)]
        [TestCase(5, 5, Direction.North, false)]
        public void Can_Robot_Be_Placed_To_New_Position(int x, int y, Direction direction, bool canPlacedToNewPosition)
        {
            // Act
            // set robot starting position to 0,0,North
            _robot.Place(0,0,Direction.North);

            //then try move robot to new position
            _robot.Place(x, y, direction);

            //if robot can be moved, the current position will be the new position
            //if not, the robot position stay at starting position 0,0,North
            Assert.AreEqual((_robot.Position.Coordinate.X == x
                && _robot.Position.Coordinate.Y == y
                && _robot.Position.Direction == direction), canPlacedToNewPosition);
        }
    }
}
