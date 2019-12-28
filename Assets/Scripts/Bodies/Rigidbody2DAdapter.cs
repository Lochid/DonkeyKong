using UnityEngine;

[RequireComponent(typeof(ITransformAdapter))]
[RequireComponent(typeof(IRigidbodyAdapter))]
[RequireComponent(typeof(ITimeAdapter))]
public class Rigidbody2DAdapter : MonoBehaviour, IBody2D
{
    public float HorizontalSpeed => rigidbodyAdapter.velocity.x;
    public float VerticalSpeed => rigidbodyAdapter.velocity.y;
    public float PositionY => transform.position.y;

    private ITransformAdapter transformAdapter;
    private IRigidbodyAdapter rigidbodyAdapter;
    private ITimeAdapter timeAdapter;

    private void Start()
    {
        transformAdapter = GetComponent<ITransformAdapter>();
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
        timeAdapter = GetComponent<ITimeAdapter>();
    }

    public void PutHorizontalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.x = force;
        rigidbodyAdapter.velocity = velocity;
    }

    public void PutVerticalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.y = force;
        rigidbodyAdapter.velocity = velocity;
    }

    public void AddVerticalPosition(float pos)
    {
        transformAdapter.Translate(new Vector2(0, 1) * timeAdapter.deltaTime * pos);
    }
}
