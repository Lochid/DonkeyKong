public interface IBody2D
{
    float HorizontalSpeed { get; }
    void MoveLeft();
    void MoveRight();
    void Stop();
}
