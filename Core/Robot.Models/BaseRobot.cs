using System;
using System.Collections.Generic;
using Robot.Models.Stage;
using Robot.Utilities;
using Robot.Utilities.Logs;

namespace Robot.Models
{
    /// <summary>
    /// Base robot class
    /// </summary>
    public abstract class BaseRobot : IRobot, IPlaceableObject
    {
        public Table Table { get; set; }
        public ILogger StringBuilderLogger { get; set; }
        public Position Position { get; set; }
        public int UnitMovement { get; set; }

        /// <summary>
        /// Robot turn left
        /// </summary>
        public void Left()
        {
            if(Position != null)
                Position.Direction = Compass.TurnToLeft(Position.Direction);
        }

        //Robot turn right
        public void Right()
        {
            if (Position != null)
                Position.Direction = Compass.TurnToRight(Position.Direction);
        }

        /// <summary>
        /// Report current position and direction of robot
        /// </summary>
        public void Report()
        {
            if (Position != null)
                StringBuilderLogger.Log(String.Format("{0},{1},{2}", Position.Coordinate.X, Position.Coordinate.Y, Position.Direction.ToString().ToUpper()));
        }

        /// <summary>
        /// Get Robot position report
        /// </summary>
        /// <returns></returns>
        public string GetReport()
        {
            return StringBuilderLogger.ToString();
        }

        /// <summary>
        /// Place robot to a new coordinate x,y facing direction(Nort,East,South,West)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public virtual void Place(int x, int y, Direction direction)
        {
            //check if robot can be move to coordinate x,y
            if (CanMoveTo(x, y))
            {
                //if robot has position then change to the new position and face
                if (Position != null)
                {
                    //first remove obj from current spot
                    Table.RemoveFromSpot(this);

                    //set to new position
                    Position.Coordinate.X = x;
                    Position.Coordinate.Y = y;
                    Position.Direction = direction;

                    //set robot to spot on the table
                    Table.AddToSpot(this);
                }
                else
                {
                    //if robot has not been placed before, then instantiate its position
                    Position = new Position(new Coordinate(x, y), direction);

                    //set robot to spot on the table
                    Table.AddToSpot(this);
                }
            }
        }

        /// <summary>
        /// Ask robot to move forward by unit movement
        /// </summary>
        /// <summary>
        /// Ask robot to move forward by unit movement
        /// </summary>
        public virtual void Move()
        {
            //check if robot has a position
            if (Position != null)
            {
                //check if robot can move to that direction by unit movement 
                if (this.CanMoveForward())
                {
                    //first remove obj from current spot
                    Table.RemoveFromSpot(this);

                    //update robot position coordinate
                    MoveActions[Position.Direction](this);

                    //set robot to spot on the table
                    Table.AddToSpot(this);
                }
            }
        }

        /// <summary>
        /// Validate if robot can move forward
        /// As long as robot is standing on the table and next movement not causing robot fall, then robot can move
        /// </summary>
        /// <param name="robot"></param>
        /// <returns>
        /// true if robot movement not cause the robot to fall
        /// false if next robot movement cause the robot to fall
        /// </returns>
        public virtual bool CanMoveForward()
        {
            bool isValid = false;

            //check if there is available spot for the new movement position
            if (Position.Direction == Direction.North && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X, Position.Coordinate.Y + UnitMovement))
                isValid = true;
            else if (Position.Direction == Direction.East && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X + UnitMovement, Position.Coordinate.Y))
                isValid = true;
            else if (Position.Direction == Direction.South && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X, Position.Coordinate.Y - UnitMovement))
                isValid = true;
            else if (Position.Direction == Direction.West && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X - UnitMovement, Position.Coordinate.Y))
                isValid = true;

            return isValid;
        }

        /// <summary>
        /// Validate if robot can be move to new x, y coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool CanMoveTo(int x, int y)
        {
            //if there is available spot on x,y, then robot can move to that point
            return Table.IsSpotExistAndNotOccupied(x,y);
        }

        protected Dictionary<Direction, Action<BaseRobot>> MoveActions = new Dictionary<Direction, Action<BaseRobot>>
        {
            {Direction.North, r => r.Position.Coordinate.Y += r.UnitMovement },
            {Direction.East, r => r.Position.Coordinate.X += r.UnitMovement },
            {Direction.South, r => r.Position.Coordinate.Y -= r.UnitMovement },
            {Direction.West, r => r.Position.Coordinate.X -=r.UnitMovement }
        };
    }
}

