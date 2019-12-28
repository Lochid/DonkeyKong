public interface IBody2D
{
    float HorizontalSpeed { get; }
    float VerticalSpeed { get; }
    void PutHorizontalForce(float force);
    void PutVerticalForce(float force);
}
