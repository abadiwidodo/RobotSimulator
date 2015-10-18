using Robot.Utilities;

namespace Robot.Models.Command
{
    public class PlaceCommand : ICommand
    {
        private readonly IRobot _robot;

        public int X;
        public int Y;
        public Direction Direction;

        public PlaceCommand(IRobot robot, int x = 0, int y = 0, Direction direction = Direction.North)
        {
            _robot = robot;

            X = x;
            Y = y;
            Direction = direction;
        }

        public void Execute()
        {
            _robot.Place(X, Y, Direction);
        }
    }
}
