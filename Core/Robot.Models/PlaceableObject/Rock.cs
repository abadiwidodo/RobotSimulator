namespace Robot.Models.PlaceableObject
{
    public class Rock : IPlaceableObject
    {
        public Position Position { get; set; }

        public Rock(Position pos)
        {
            Position = pos;
        }
    }
}
