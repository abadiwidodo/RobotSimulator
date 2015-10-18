using Robot.Models.Stage;
using Robot.Utilities;
using Robot.Utilities.Logs;

namespace Robot.Models
{
    public interface IRobot
    {
        ILogger StringBuilderLogger { get; set; }
        Table Table { get; set; }
        Position Position { get; set; }
        int UnitMovement { get; set; }

        void Place(int x, int y, Direction face);
        void Move();
        void Left();
        void Right();
        void Report();
        string GetReport();
    }
}
