
namespace Robot.Models.Stage
{
    public interface IStage<T>
    {
        bool CanMoveForward(T entity);
        bool IsWithinStage(Coordinate coordinate);
    }
}
