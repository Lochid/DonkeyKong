using UnityEngine;

[RequireComponent(typeof(IRigidbodyAdapter))]
[RequireComponent(typeof(ITimeAdapter))]
public class RiseMotion : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 100;

    private IRigidbodyAdapter rigidbodyAdapter;
    private ITimeAdapter timeAdapter;

    private void Start()
    {
        rigidbodyAdapter = GetComponent<IRigidbodyAdapter>();
        timeAdapter = GetComponent<ITimeAdapter>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        rigidbodyAdapter.MovePosition(rigidbodyAdapter.position + (new Vector2(0, 1) * timeAdapter.deltaTime * verticalSpeed));
    }
}