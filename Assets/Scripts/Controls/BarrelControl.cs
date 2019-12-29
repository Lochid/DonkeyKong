using UnityEngine;

public class BarrelControl : MonoBehaviour, IHorizontalControl, IMirrorTurnControl
{
    public bool MoveLeft => !MoveRight;
    public bool MoveRight { get; private set; } = true;

    public void Turn()
    {
        MoveRight = !MoveRight;
    }
}
