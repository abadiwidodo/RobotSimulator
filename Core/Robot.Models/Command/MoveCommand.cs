namespace Robot.Models.Command
{
    public class MoveCommand : ICommand
    {
        private readonly IRobot _robot;

        public MoveCommand(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.Move();
        }
    }
}
