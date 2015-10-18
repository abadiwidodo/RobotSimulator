using Robot.Utilities;

namespace Robot.Models.Stage
{
    public class Table : IStage<IRobot>
    {
        public int Width;
        public int Height;

        public int MaxXCoordinate
        {
            get
            {
                return Width - 1;
            }
        }

        public int MaxYCoordinate
        {
            get
            {
                return Height - 1;
            }
        }

        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// As long as robot is standing on the table and next movement not causing robot fall, then robot can move
        /// </summary>
        /// <param name="robot"></param>
        /// <returns>
        /// true if robot movement not cause the robot to fall
        /// false if next robot movement cause the robot to fall
        /// </returns>
        public bool CanMoveForward(IRobot robot)
        {
            if (robot.Position.Direction == Direction.North && robot.Position.Coordinate.Y + robot.UnitMovement > MaxYCoordinate)
                return false;
            else if (robot.Position.Direction == Direction.East && robot.Position.Coordinate.X + robot.UnitMovement > MaxXCoordinate)
                return false;
            else if (robot.Position.Direction == Direction.South && robot.Position.Coordinate.Y - robot.UnitMovement < 0)
                return false;
            else if (robot.Position.Direction == Direction.West && robot.Position.Coordinate.X - robot.UnitMovement < 0)
                return false;

            return true;
        }

        /// <summary>
        /// Check if coordinate x,y within the stage
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public bool IsWithinStage(Coordinate coordinate)
        {
            return (coordinate.X >= 0 && coordinate.X <= MaxXCoordinate 
                && coordinate.Y >= 0 && coordinate.Y <= MaxYCoordinate);
        }
    }
}
