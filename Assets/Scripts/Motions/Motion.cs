
using UnityEngine;

[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IJumpControl))]
[RequireComponent(typeof(IRigidbodyAdapter))]
public class Motion : MonoBehaviour, IWalkMotion, IJumpMotion
{
    [SerializeField]
    private float horizontalSpeed = 500f;
    [SerializeField]
    private float verticalSpeed = 500f;

    public bool WalkLeft => rigidbodyAdapter.velocity.x < -0.5f;
    public bool WalkRight => rigidbodyAdapter.velocity.x > 0.5f;
    public bool Walk => WalkLeft || WalkRight;
    public bool Fall => Mathf.Abs(rigidbodyAdapter.velocity.y) > 1f;
    public bool Stop => !Walk && !Fall;
    public bool Land { get; private set; } = false;

    private IHorizontalControl horizontalControl;
    private IJumpControl jumpControl;
    private IRigidbodyAdapter rigidbodyAdapter;
    private bool prevFall;

    private void Start()
    {
        horizontalControl = GetComponent<IHorizontalControl>();
        jumpControl = GetComponent<IJumpControl>();
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
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
            PutHorizontalForce(-horizontalSpeed);
        }
    }

    private void CheckAndMoveRight()
    {
        if (horizontalControl.MoveRight && !Fall)
        {
            PutHorizontalForce(horizontalSpeed);
        }
    }

    private void CheckAndMoveUp()
    {
        if (jumpControl.Jump && !Fall)
        {
            PutVerticalForce(verticalSpeed);
        }
    }

    private void CheckAndStop()
    {
        if (!horizontalControl.MoveLeft && !horizontalControl.MoveRight && !Fall)
        {
            PutHorizontalForce(0);
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

    private void PutHorizontalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.x = force;
        rigidbodyAdapter.velocity = velocity;
    }

    private void PutVerticalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.y = force;
        rigidbodyAdapter.velocity = velocity;
    }
}
