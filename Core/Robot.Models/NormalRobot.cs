using Robot.Models.Stage;
using Robot.Utilities.Logs;

namespace Robot.Models
{
    public class NormalRobot : BaseRobot
    {
        public NormalRobot()
        {
            Table = new Table(5,5);
            StringBuilderLogger = new StringBuilderLogger();
            UnitMovement = 1;
        }

        public NormalRobot(Table table, ILogger logger)
        {
            Table = table;
            StringBuilderLogger = logger;
            UnitMovement = 1;
        }
    }
}