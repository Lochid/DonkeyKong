using UnityEngine;

public class BarrelControl : MonoBehaviour, IHorizontalControl
{
    public bool MoveLeft { get; } = false;
    public bool MoveRight { get; } = true;
}
