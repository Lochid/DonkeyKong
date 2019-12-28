
using UnityEngine;

[RequireComponent(typeof(IRigidbodyAdapter))]
public class MotionStates : MonoBehaviour, IWalkMotionState, IJumpMotionState
{
    public bool WalkLeft => rigidbodyAdapter.velocity.x < -0.5f;
    public bool WalkRight => rigidbodyAdapter.velocity.x > 0.5f;
    public bool Walk => WalkLeft || WalkRight;
    public bool Fall => Mathf.Abs(rigidbodyAdapter.velocity.y) > 1f;
    public bool Stop => !Walk && !Fall;
    public bool Land { get; private set; } = false;


    private IRigidbodyAdapter rigidbodyAdapter;

    private bool prevFall;

    private void Start()
    {
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
    }

    private void FixedUpdate()
    {
        CheckLand();
        UpdateFall();
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
