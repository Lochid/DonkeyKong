using System;
using UnityEngine;

[RequireComponent(typeof(ITransformAdapter))]
[RequireComponent(typeof(ITimeAdapter))]
public class ElevatorMotion : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 10;
    [SerializeField]
    private float lastPosition = 10;

    public event Action<ElevatorMotion> CompletedMotion;

    private ITransformAdapter transformAdapter;
    private ITimeAdapter timeAdapter;
    private float startPosition;
    private bool done = false;

    private void Start()
    {
        transformAdapter = GetComponent<ITransformAdapter>();
        startPosition = transformAdapter.position.y;
        CompletedMotion += (ElevatorMotion motion) => { };
        timeAdapter = GetComponent<ITimeAdapter>();
    }

    private void FixedUpdate()
    {
        CheckPosition();
        Move();
    }

    private void CheckPosition()
    {
        if (Math.Abs(transformAdapter.position.y - startPosition) >= Math.Abs(lastPosition))
        {
            done = true;
            CompletedMotion(this);
        }
    }


    private void Move()
    {
        if (!done)
        {
            AddVerticalPosition(verticalSpeed);
        }
    }

    private void AddVerticalPosition(float pos)
    {
        transformAdapter.Translate(new Vector2(0, 1) * timeAdapter.deltaTime * pos);
    }
}