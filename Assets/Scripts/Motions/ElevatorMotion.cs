using System;
using UnityEngine;

[RequireComponent(typeof(IBody2D))]
public class ElevatorMotion : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 10;
    [SerializeField]
    private float lastPosition = 10;

    public event Action<ElevatorMotion> CompletedMotion;

    private IBody2D body;
    private float startPosition;
    private bool done = false;

    private void Start()
    {
        body = GetComponent<IBody2D>();
        startPosition = body.PositionY;
        CompletedMotion += (ElevatorMotion motion) => { };
    }

    private void FixedUpdate()
    {
        CheckPosition();
        Move();
    }

    private void CheckPosition()
    {
        if (Math.Abs(body.PositionY - startPosition) >= Math.Abs(lastPosition))
        {
            done = true;
            CompletedMotion(this);
        }
    }


    private void Move()
    {
        if (!done)
        {
            body.AddVerticalPosition(verticalSpeed);
        }
    }
}