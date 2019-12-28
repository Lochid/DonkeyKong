public interface IBody2D
{
    float PositionY { get; }
    float HorizontalSpeed { get; }
    float VerticalSpeed { get; }
    void PutHorizontalForce(float force);
    void PutVerticalForce(float force);
    void AddVerticalPosition(float position);
}
