using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Robot.Utilities.UnitTests.Compass
{
    [TestFixture]
    public class CompassUnitTests
    {
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void Compass_Turn_Right_Should_Direction_Correct_Direction(Direction currentDirection, Direction expectedDirection)
        {
            // Act
            Assert.IsTrue(Utilities.Compass.TurnToRight(currentDirection) == expectedDirection);
        }

        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.West, Direction.South)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.East, Direction.North)]
        public void Compass_Turn_Left_Should_Direction_Correct_Direction(Direction currentDirection, Direction expectedDirection)
        {
            // Act
            Assert.IsTrue(Utilities.Compass.TurnToLeft(currentDirection) == expectedDirection);
        }

        [TestCase(Direction.North, Direction.South)]
        [TestCase(Direction.East, Direction.West)]
        public void Compass_Turn_Around_Should_Direction_Opposite_Direction(Direction currentDirection, Direction expectedDirection)
        {
            // Act
            Assert.IsTrue(Utilities.Compass.TurnAround(currentDirection) == expectedDirection);
        }
    }
}
