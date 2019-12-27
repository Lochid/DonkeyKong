using UnityEngine;

[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IBody2D))]
public class Motion : MonoBehaviour, IWalkMotion
{
    public bool WalkLeft => body.HorizontalSpeed < -0.5f;
    public bool WalkRight => body.HorizontalSpeed > 0.5f;
    public bool Stop => !WalkLeft && !WalkRight;
    public bool Walk => !Stop;

    private IHorizontalControl horizontalControl;
    private IBody2D body;

    private void Start()
    {
        horizontalControl = GetComponent<IHorizontalControl>();
        body = GetComponent<IBody2D>();
    }

    private void FixedUpdate()
    {
        CheckAndMoveLeft();
        CheckAndMoveRight();
        CheckAndStop();
    }

    private void CheckAndMoveLeft()
    {
        if (horizontalControl.MoveLeft)
        {
            body.MoveLeft();
        }
    }

    private void CheckAndMoveRight()
    {
        if (horizontalControl.MoveRight)
        {
            body.MoveRight();
        }
    }

    private void CheckAndStop()
    {
        if (!horizontalControl.MoveLeft && !horizontalControl.MoveRight)
        {
            body.Stop();
        }
    }
}
