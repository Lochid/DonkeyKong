using UnityEngine;

[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IBody2D))]
public class Motion : MonoBehaviour, IWalkMotion
{
    public bool WalkLeft => body.HorizontalSpeed < -0.5f;
    public bool WalkRight => body.HorizontalSpeed > 0.5f;
    public bool Walk => WalkLeft || WalkRight;
    public bool Fall => Mathf.Abs(body.VerticalSpeed) > 0.5f;
    public bool Stop => !Walk && !Fall;

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
        if (horizontalControl.MoveLeft && !Fall)
        {
            body.MoveLeft();
        }
    }

    private void CheckAndMoveRight()
    {
        if (horizontalControl.MoveRight && !Fall)
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
