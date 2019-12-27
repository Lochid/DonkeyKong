using UnityEngine;

[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IBody2D))]
public class Motion : MonoBehaviour, IWalkMotion
{
    public bool WalkLeft { get; private set; }
    public bool WalkRight { get; private set; }

    private IHorizontalControl horizontalControl;
    private IBody2D body;

    private void Start()
    {
        horizontalControl = GetComponent<IHorizontalControl>();
        body = GetComponent<IBody2D>();
    }

    private void FixedUpdate()
    {
        body.MoveLeft();
    }
}
