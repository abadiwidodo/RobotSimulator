using System;
using System.Linq;
using Robot.Models.Command;
using Robot.Utilities.Extensions;

namespace Robot.Models.Extensions
{
    public static class StringCommandExtension
    {
        /// <summary>
        /// Validate string input as valid command or not
        /// Acceptable string format is "PLACE {any string},{any string},{any string}",
        /// "PLACE","MOVE", "RIGHT", "LEFT", "REPORT"
        /// </summary>
        /// <param name="inputCommand">input command string</param>
        /// <returns>true is valid command format</returns>
        public static bool IsValidRobotCommand(this string inputCommand)
        {
            bool isValid = true;

            string commandInputName = string.Empty;
            var args = new string[]{};

            ExtractArgsFromCommandString(inputCommand, ref commandInputName, ref args);

            if (!String.IsNullOrEmpty(commandInputName))
            {
                //first check if valid Command Enum
                if (!commandInputName.IsValidEnum<CommandType>()) isValid = false;

                //check if command is Place command then make sure it has 3 args
                if (commandInputName.ToEnum<CommandType>() == CommandType.Place)
                {
                    isValid = args.Any() && args.Count() == 3;
                }
            }
            else
            {
                isValid = false;
            }
            
            return isValid;
        }

        /// <summary>
        /// Extract string command into command name and args(if any)
        /// Example:
        /// "PLACE 0,0,NORTH" will be extracted into
        ///     commandName = "PLACE"
        ///     args = string["0","0","NORTH"]
        /// 
        /// 
        /// "PLACE 0, 0, NORTH" will be extracted into
        ///     commandName = "PLACE"
        ///     args = string["0","0","NORTH"] 
        /// any space( " " ) between args will be removed
        /// 
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        public static void ExtractArgsFromCommandString(string inputCommand, ref string commandName, ref string[] args)
        {
            string[] strings = inputCommand.Split(' ');

            if (strings.Any())
            {
                commandName = strings[0];

                //in some case user put space between , ex: 0, 0, NORTH instead of 0,0,NORTH
                //so remove the first string from array, join the rest array into string, remove space, split into array by ','
                args = String.Join("", strings.Skip(1)).Replace(" ", "").Split(',');
            }
        }
    }
}
