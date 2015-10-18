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
    public abstract class BaseRobot : IRobot
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
        public void Place(int x, int y, Direction direction)
        {
            //check if robot can be move to coordinate x,y
            if (CanMoveTo(x, y))
            {
                //if robot has position then change to the new position and face
                if (Position != null)
                {
                    Position.Coordinate.X = x;
                    Position.Coordinate.Y = y;
                    Position.Direction = direction;
                }
                else
                {
                    //if robot has not been placed before, then instantiate its position
                    Position = new Position(new Coordinate(x, y), direction);
                }
            }
        }

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
                    MoveActions[Position.Direction](this);
                }
            }
        }

        /// <summary>
        /// Validate if robot can move forward
        /// Robot can move forward if   
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanMoveForward()
        {
            //if new movement not cross the table boundary then it's good
            return Table.CanMoveForward(this);
        }

        /// <summary>
        /// Validate if robot can be move to new x, y coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual bool CanMoveTo(int x, int y)
        {
            //if new coordinate still within the table boundary then it's good
            return Table.IsWithinStage(new Coordinate(x, y));
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

