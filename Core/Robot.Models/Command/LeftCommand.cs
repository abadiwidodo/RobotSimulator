namespace Robot.Models.Command
{
    public class LeftCommand : ICommand
    {
        private readonly IRobot _robot;

        public LeftCommand(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.Left();
        }
    }
}
