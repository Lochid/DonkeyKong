
using UnityEngine;

[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IJumpControl))]
[RequireComponent(typeof(IBody2D))]
public class Motion : MonoBehaviour, IWalkMotion, IJumpMotion
{
    [SerializeField]
    private float horizontalSpeed = 500f;
    [SerializeField]
    private float verticalSpeed = 500f;

    public bool WalkLeft => body.HorizontalSpeed < -0.5f;
    public bool WalkRight => body.HorizontalSpeed > 0.5f;
    public bool Walk => WalkLeft || WalkRight;
    public bool Fall => Mathf.Abs(body.VerticalSpeed) > 1f;
    public bool Stop => !Walk && !Fall;
    public bool Land { get; private set; } = false;

    private IHorizontalControl horizontalControl;
    private IJumpControl jumpControl;
    private IBody2D body;
    private bool prevFall;

    private void Start()
    {
        horizontalControl = GetComponent<IHorizontalControl>();
        jumpControl = GetComponent<IJumpControl>();
        body = GetComponent<IBody2D>();
    }

    private void FixedUpdate()
    {
        CheckAndMoveLeft();
        CheckAndMoveRight();
        CheckAndMoveUp();
        CheckAndStop();
        CheckLand();
        UpdateFall();
    }

    private void CheckAndMoveLeft()
    {
        if (horizontalControl.MoveLeft && !Fall)
        {
            body.PutHorizontalForce(-horizontalSpeed);
        }
    }

    private void CheckAndMoveRight()
    {
        if (horizontalControl.MoveRight && !Fall)
        {
            body.PutHorizontalForce(horizontalSpeed);
        }
    }

    private void CheckAndMoveUp()
    {
        if (jumpControl.Jump && !Fall)
        {
            body.PutVerticalForce(verticalSpeed);
        }
    }

    private void CheckAndStop()
    {
        if (!horizontalControl.MoveLeft && !horizontalControl.MoveRight && !Fall)
        {
            body.PutHorizontalForce(0);
        }
    }

    private void CheckLand()
    {
        if (!Fall && prevFall)
        {
            Land = true;
        }
        else
        {
            Land = false;
        }
    }

    private void UpdateFall()
    {
        prevFall = Fall;
    }
}
