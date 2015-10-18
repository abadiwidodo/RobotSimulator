namespace Robot.Models.Command
{
    public class ReportCommand : ICommand
    {
        private readonly IRobot _robot;

        public ReportCommand(IRobot robot)
        {
            _robot = robot;
        }
        public void Execute()
        {
            _robot.Report();
        }
    }
}
