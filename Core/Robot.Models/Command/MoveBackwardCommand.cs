namespace Robot.Models.Command
{
    public class MoveBackwardCommand : ICommand
    {
        private readonly IRobot _robot;

        public MoveBackwardCommand(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            if (_robot as IRobotMarkTwo != null)
            {
                ((IRobotMarkTwo) _robot).MoveBackward();
            }
        }
    }
}
