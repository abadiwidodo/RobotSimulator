using System;
using System.Collections.Generic;
using Robot.Models.Stage;
using Robot.Utilities;
using Robot.Utilities.Logs;

namespace Robot.Models
{
    public class ToyRobotMarkTwo : BaseRobot, IRobotMarkTwo
    {
        public ToyRobotMarkTwo()
        {
            Table = new Table(5,5);
            StringBuilderLogger = new StringBuilderLogger();
            UnitMovement = 1;
        }

        public ToyRobotMarkTwo(Table table, ILogger logger)
        {
            Table = table;
            StringBuilderLogger = logger;
            UnitMovement = 1;
        }
        
        /// <summary>
        /// Robot turn around to the opposite direction
        /// </summary>
        public void TurnAround()
        {
            if (Position != null)
                Position.Direction = Compass.TurnAround(Position.Direction);
        }

        /// <summary>
        /// Robot move backward
        /// </summary>
        public void MoveBackward()
        {
            //check if robot has a position
            if (Position != null)
            {
                //check if robot can not move 
                if (this.CanMoveBackward())
                {
                    //first remove obj from current spot
                    Table.RemoveFromSpot(this);

                    //update robot position coordinate
                    MoveBackwardActions[Position.Direction](this);

                    //set robot to spot on the table
                    Table.AddToSpot(this);
                }
            }
        }

        protected virtual bool CanMoveBackward()
        {
            //if new movement not cross the table boundary then it's good
            //return Table.CanMoveForward(this);
            bool isValid = false;

            if (Position.Direction == Direction.North && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X, Position.Coordinate.Y - UnitMovement))
                isValid = true;
            else if (Position.Direction == Direction.East && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X - UnitMovement, Position.Coordinate.Y))
                isValid = true;
            else if (Position.Direction == Direction.South && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X, Position.Coordinate.Y + UnitMovement))
                isValid = true;
            else if (Position.Direction == Direction.West && Table.IsSpotExistAndNotOccupied(Position.Coordinate.X + UnitMovement, Position.Coordinate.Y))
                isValid = true;

            return isValid;
        }

        protected Dictionary<Direction, Action<BaseRobot>> MoveBackwardActions = new Dictionary<Direction, Action<BaseRobot>>
        {
            {Direction.North, r => r.Position.Coordinate.Y -= r.UnitMovement },
            {Direction.East, r => r.Position.Coordinate.X -= r.UnitMovement },
            {Direction.South, r => r.Position.Coordinate.Y += r.UnitMovement },
            {Direction.West, r => r.Position.Coordinate.X +=r.UnitMovement }
        };
    }
}