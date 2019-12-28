using UnityEngine;

public interface IPhysicsAdapter
{
    RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance);
}
