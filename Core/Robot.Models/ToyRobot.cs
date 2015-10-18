using Robot.Models.Stage;
using Robot.Utilities.Logs;

namespace Robot.Models
{
    public class ToyRobot : BaseRobot
    {
        public ToyRobot()
        {
            Table = new Table(5,5);
            StringBuilderLogger = new StringBuilderLogger();
            UnitMovement = 1;
        }

        public ToyRobot(Table table, ILogger logger)
        {
            Table = table;
            StringBuilderLogger = logger;
            UnitMovement = 1;
        }
    }
}