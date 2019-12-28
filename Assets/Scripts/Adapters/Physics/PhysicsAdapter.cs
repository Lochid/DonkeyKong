using UnityEngine;

public class PhysicsAdapter : MonoBehaviour, IPhysicsAdapter
{
    public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance)
    {
        return Physics2D.Raycast(origin, direction, distance);
    }
}
