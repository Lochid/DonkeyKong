public interface IBody2D
{
    float HorizontalSpeed { get; }
    float VerticalSpeed { get; }
    void MoveLeft();
    void MoveRight();
    void Stop();
}
