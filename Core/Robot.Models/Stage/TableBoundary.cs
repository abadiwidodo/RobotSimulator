using Robot.Models.Robots;

namespace Robot.Models
{
    public class TableBoundary : IBoundary<Position>
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

        public TableBoundary(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsWithinBoundary(Position position)
        {
            return (position.Coordinate.x > 0 
                && position.Coordinate.x <= MaxXCoordinate 
                && position.Coordinate.y > 0 
                && position.Coordinate.y <= MaxYCoordinate);
        }
    }
}
