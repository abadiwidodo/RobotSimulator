using System.Collections.Generic;
using System.Linq;
using Robot.Models.PlaceableObject;

namespace Robot.Models.Stage
{
    /// <summary>
    /// Table is the stage of placeable object
    /// </summary>
    public class Table : IStage<IPlaceableObject>
    {
        public List<Spot> Spots = new List<Spot>();

        public Table(int width, int height)
        {
            //create available spots on the table based on width and height
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Spots.Add(new Spot(x, y));
                }
            }
        }

        /// <summary>
        /// Remove obj from current obj's spot
        /// </summary>
        /// <param name="obj"></param>
        public void RemoveFromSpot(IPlaceableObject obj)
        {
            Spot spot = Spots.FirstOrDefault(s => s.Coordinate.X == obj.Position.Coordinate.X && s.Coordinate.Y == obj.Position.Coordinate.Y);
            if (spot != null) spot.CurrentObject = null;
        }

        /// <summary>
        /// add object to new spot
        /// </summary>
        /// <param name="obj"></param>
        public void AddToSpot(IPlaceableObject obj)
        {
            Spot spot = Spots.FirstOrDefault(s => s.Coordinate.X == obj.Position.Coordinate.X && s.Coordinate.Y == obj.Position.Coordinate.Y);
            if (spot != null) spot.CurrentObject = obj;
        }

        /// <summary>
        /// Check if the spot x,y is exist and not occupied by any placeable object
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>true if spot is available, false if spot is either not exist or occupied by placeable obj</returns>
        public bool IsSpotExistAndNotOccupied(int x, int y)
        {
            return Spots.Any(s => s.Coordinate.X == x && s.Coordinate.Y == y && s.CurrentObject == null);
        }
    }
}
