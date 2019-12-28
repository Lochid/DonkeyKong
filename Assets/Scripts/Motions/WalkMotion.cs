
using UnityEngine;

[RequireComponent(typeof(IRigidbodyAdapter))]
[RequireComponent(typeof(IHorizontalControl))]
[RequireComponent(typeof(IJumpMotionState))]
public class WalkMotion : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 500f;
    [SerializeField]
    private float verticalSpeed = 500f;

    private IRigidbodyAdapter rigidbodyAdapter;
    private IHorizontalControl horizontalControl;
    private IJumpMotionState jumpState;

    private bool prevFall;

    private void Start()
    {
        horizontalControl = GetComponent<IHorizontalControl>();
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
        jumpState = GetComponent<IJumpMotionState>();
    }

    private void FixedUpdate()
    {
        CheckAndMoveLeft();
        CheckAndMoveRight();
        CheckAndStop();
    }

    private void CheckAndMoveLeft()
    {
        if (horizontalControl.MoveLeft && !jumpState.Fall)
        {
            PutHorizontalForce(-horizontalSpeed);
        }
    }

    private void CheckAndMoveRight()
    {
        if (horizontalControl.MoveRight && !jumpState.Fall)
        {
            PutHorizontalForce(horizontalSpeed);
        }
    }

    private void CheckAndStop()
    {
        if (!horizontalControl.MoveLeft && !horizontalControl.MoveRight && !jumpState.Fall)
        {
            PutHorizontalForce(0);
        }
    }

    private void PutHorizontalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.x = force;
        rigidbodyAdapter.velocity = velocity;
    }
}
