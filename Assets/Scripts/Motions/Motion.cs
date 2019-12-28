using System;
using UnityEngine;

[RequireComponent(typeof(IBody2D))]
public class ElevatorMotion : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 10;
    [SerializeField]
    private float lastPosition = 10;

    private IBody2D body;
    private float startPosition;

    private void Start()
    {
        body = GetComponent<IBody2D>();
        startPosition = body.PositionY;
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        if (Math.Abs(body.PositionY - startPosition) < Math.Abs(lastPosition))
        {
            body.AddVerticalPosition(verticalSpeed);
        }
    }
}
