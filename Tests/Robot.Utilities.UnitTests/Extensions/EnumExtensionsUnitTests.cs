using NUnit.Framework;
using Robot.Utilities.Extensions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Robot.Utilities.UnitTests.Extensions
{
    [TestFixture]
    public class EnumUnitTests
    {
        [TestCase("NORTH", Direction.North)]
        [TestCase("North", Direction.North)]
        [TestCase("north", Direction.North)]
        [TestCase("EAST", Direction.East)]
        [TestCase("East", Direction.East)]
        [TestCase("east", Direction.East)]
        [TestCase("SOUTH", Direction.South)]
        [TestCase("South", Direction.South)]
        [TestCase("south", Direction.South)]
        [TestCase("WEST", Direction.West)]
        [TestCase("West", Direction.West)]
        [TestCase("west", Direction.West)]
        public void Enum_Convert_Should_Return_Correct_Direction(string enumDirectionString, Direction expectedDirection)
        {
            Direction direction = Direction.North;
            EnumExtension.TryParse(enumDirectionString, ref direction);

            Assert.AreEqual(expectedDirection, direction);
        }
    }
}
