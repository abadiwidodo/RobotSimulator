
namespace Robot.Models.Stage
{
    public interface IStage<T>
    {
        void AddToSpot(T toyRobotMarkTwo);
        void RemoveFromSpot(T toyRobotMarkTwo);
    }
}
