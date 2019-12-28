
using UnityEngine;

[RequireComponent(typeof(IRigidbodyAdapter))]
[RequireComponent(typeof(IJumpControl))]
[RequireComponent(typeof(IJumpMotionState))]
public class JumpMotion : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 500f;
    [SerializeField]
    private float verticalSpeed = 500f;

    private IRigidbodyAdapter rigidbodyAdapter;
    private IJumpControl jumpControl;
    private IJumpMotionState jumpState;

    private bool prevFall;

    private void Start()
    {
        jumpControl = GetComponent<IJumpControl>();
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
        jumpState = GetComponent<IJumpMotionState>();
    }

    private void FixedUpdate()
    {
        CheckAndMoveUp();
    }

    private void CheckAndMoveUp()
    {
        if (jumpControl.Jump && !jumpState.Fall)
        {
            PutVerticalForce(verticalSpeed);
        }
    }

    private void PutVerticalForce(float force)
    {
        var velocity = rigidbodyAdapter.velocity;
        velocity.y = force;
        rigidbodyAdapter.velocity = velocity;
    }
}
