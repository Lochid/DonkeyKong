using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyAdapter : MonoBehaviour, IRigidbodyAdapter
{
    public Vector2 velocity
    {
        get => body.velocity;
        set => body.velocity = value;
    }

    public Vector2 position
    {
        get => body.position;
        set => body.position = value;
    }

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
}
