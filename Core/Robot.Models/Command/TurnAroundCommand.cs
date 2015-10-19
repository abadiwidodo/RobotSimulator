namespace Robot.Models.Command
{
    public class TurnAroundCommand : ICommand
    {
        private readonly IRobot _robot;

        public TurnAroundCommand(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            if (_robot as IRobotMarkTwo != null)
            {
                ((IRobotMarkTwo)_robot).TurnAround();            
            }
        }
    }
}
