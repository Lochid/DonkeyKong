using UnityEngine;

public interface IRigidbodyAdapter
{
    Vector2 velocity { get; set; }
    Vector2 position { get; set; }
    void MovePosition(Vector2 position);
}
