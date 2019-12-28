
using UnityEngine;

[RequireComponent(typeof(IRigidbodyAdapter))]
[RequireComponent(typeof(IPhysicsAdapter))]
public class MotionStates : MonoBehaviour, IWalkMotionState, IJumpMotionState
{
    [SerializeField]
    private Vector2 positionOffset = new Vector2(0, 33);
    [SerializeField]
    private float raycastOffset = 0.00005f;

    public bool WalkLeft => rigidbodyAdapter.velocity.x < -0.5f;
    public bool WalkRight => rigidbodyAdapter.velocity.x > 0.5f;
    public bool Walk => WalkLeft || WalkRight;
    public bool Fall
    {
        get
        {
            var withVerticalSpeed = Mathf.Abs(rigidbodyAdapter.velocity.y) > 1f;
            if (!withVerticalSpeed)
            {
                return withVerticalSpeed;
            }

            var hit = physicsAdapter.Raycast(rigidbodyAdapter.position + positionOffset, Vector2.down, raycastOffset);

            return hit.collider == null;
        }
    }

    public bool Stop => !Walk && !Fall;
    public bool Land { get; private set; } = false;


    private IRigidbodyAdapter rigidbodyAdapter;
    private IPhysicsAdapter physicsAdapter;

    private bool prevFall;

    private void Start()
    {
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
        physicsAdapter = GetComponent<IPhysicsAdapter>();
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
