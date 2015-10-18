using System;
using System.Linq;
using Robot.Models.Extensions;
using Robot.Utilities;
using Robot.Utilities.Extensions;

namespace Robot.Models.Command
{
    public static class CommandFactory
    {
        /// <summary>
        /// Get proper command based on command input string
        /// </summary>
        /// <param name="commandInput"></param>
        /// <param name="robot"></param>
        /// <returns></returns>
        public static ICommand Get(string inputCommand, IRobot robot)
        {
            string commandInputName = string.Empty;
            var args = new string[] { };

            StringCommandExtension.ExtractArgsFromCommandString(inputCommand, ref commandInputName, ref args);

            ICommand command = null;

            if (!String.IsNullOrEmpty(commandInputName))
            {
                switch (commandInputName.ToEnum<CommandType>())
                {
                    case CommandType.Place:

                        //try parse args string into Position
                        Position pos = null;

                        if (TryParseArgsIntoPosition(args, ref pos))
                        {
                            command = new PlaceCommand(robot, pos.Coordinate.X, pos.Coordinate.Y, pos.Direction);
                        }

                        break;

                    case CommandType.Right:
                        command = new RightCommand(robot);
                        break;

                    case CommandType.Left:
                        command = new LeftCommand(robot);
                        break;

                    case CommandType.Move:
                        command = new MoveCommand(robot);
                        break;

                    case CommandType.Report:
                        command = new ReportCommand(robot);
                        break;
                }
            }

            return command;
        }

        /// <summary>
        /// Try parse string command into Robot Position 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool TryParseArgsIntoPosition(string[] commandArgs, ref Position pos)
        {
            bool canParse = false;

            int x, y;
            Direction direction = Direction.North;

            //first make sure there are 3 args for x, y, direction facing
            if (commandArgs.Count() == 3)
            {
                //Setup x y and direction
                if (Int32.TryParse(commandArgs[0], out x)
                    && Int32.TryParse(commandArgs[1], out y)
                    && EnumExtension.TryParse<Direction>(commandArgs[2], ref direction))
                {
                    canParse = true;
                    pos = new Position(new Coordinate(x, y), direction);
                }
            }
            return canParse;
        }
    }
}
