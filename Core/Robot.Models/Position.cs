using Robot.Utilities;

namespace Robot.Models
{
    /// <summary>
    /// Position at coordinate x,y facing direction
    /// </summary>
    public class Position
    {
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }

        public Position(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }
    }
}
