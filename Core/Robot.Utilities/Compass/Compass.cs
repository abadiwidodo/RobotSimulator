using System.Collections.Generic;
using System.Linq;

namespace Robot.Utilities
{
    /// <summary>
    /// Compass class that can help detect your direction
    /// can extend to Southwest instead of 90 degree you can also turn 45 degree etc
    /// </summary>
    public class Compass
    {
        private static readonly List<Direction> directions = new List<Direction>
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        };

        private static readonly Dictionary<int, Direction> CompassDirections = new Dictionary<int, Direction>
        {
            {0, Direction.North},
            {90, Direction.East},
            {180, Direction.South},
            {270, Direction.West}
        };

        public static Direction MapDirection(int degree)
        {
            return CompassDirections[degree];
        }

        public static Direction TurnDirection(Direction currentFace, int degree)
        {
            int currentdegree =
                CompassDirections.AsQueryable().FirstOrDefault(x => x.Value == currentFace).Key;

            if (currentdegree == 0) currentdegree = 360;

            int newdegree = (currentdegree + degree) % 360;

            return CompassDirections[newdegree];
        }

        /// <summary>
        /// Turn 90 degree from the current direction
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Direction TurnToRight(Direction face)
        {
            return TurnDirection(face, 90);
        }

        /// <summary>
        /// Turn -90 degree from the current direction
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Direction TurnToLeft(Direction face)
        {
            return TurnDirection(face, -90);
        }

        /// <summary>
        /// Turn around 180 degree from the current direction
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Direction TurnAround(Direction face)
        {
            return TurnDirection(face, 180);
        }
    }
}
