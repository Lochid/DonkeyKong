using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DAdapter : MonoBehaviour, IBody2D
{
    public float HorizontalSpeed => body.velocity.x;

    [SerializeField]
    private float horizontalSpeed = 500f;
    private Rigidbody2D body;
    private Vector2 horizontalMoveVector;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        horizontalMoveVector = new Vector2(horizontalSpeed, 0);
    }


    public void MoveLeft()
    {
        var velocity = body.velocity;
        velocity.x = -horizontalSpeed;
        body.velocity = velocity;
    }

    public void MoveRight()
    {
        var velocity = body.velocity;
        velocity.x = horizontalSpeed;
        body.velocity = velocity;
    }

    public void Stop()
    {
        var velocity = body.velocity;
        velocity.x = 0;
        body.velocity = velocity;
    }
}
