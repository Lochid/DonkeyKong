using UnityEngine;

[RequireComponent(typeof(ITransformAdapter))]
[RequireComponent(typeof(ITimeAdapter))]
public class RiseMotion : MonoBehaviour
{
    [SerializeField]
    private readonly float verticalSpeed = 100;

    private ITransformAdapter transformAdapter;
    private ITimeAdapter timeAdapter;

    private void Start()
    {
        transformAdapter = GetComponent<ITransformAdapter>();
        timeAdapter = GetComponent<ITimeAdapter>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        transformAdapter.Translate(new Vector2(0, 1) * timeAdapter.deltaTime * verticalSpeed);
    }
}