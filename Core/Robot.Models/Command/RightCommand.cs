namespace Robot.Models.Command
{
    public class RightCommand : ICommand
    {
        private readonly IRobot _robot;

        public RightCommand(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.Right();
        }
    }
}
