﻿using Robot.Models.PlaceableObject;

namespace Robot.Models.Stage
{
    public class Spot
    {
        public Coordinate Coordinate { get; set; }
        public IPlaceableObject CurrentObject { get; set; }

        public Spot(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public Spot(int x, int y)
        {
            Coordinate = new Coordinate(x,y);
        }

        public void SetSpot(IPlaceableObject obj)
        {
            CurrentObject = obj;
        }
    }
}
